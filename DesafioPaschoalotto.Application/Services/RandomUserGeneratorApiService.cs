using DesafioPaschoalotto.Application.Dto;
using DesafioPaschoalotto.Application.Interfaces;
using DesafioPaschoalotto.Application.Utils;
using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Repositories;
using System.Transactions;

namespace DesafioPaschoalotto.Application.Services
{
    public class RandomUserGeneratorApiService : IRandomUserGeneratorApiService
    {

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IUnitOfWork _uow;

        public RandomUserGeneratorApiService(IHttpClientFactory httpClientFactory, IUserRepository userRepository, IContactRepository contactRepository, ILocationRepository locationRepository, IDocumentRepository documentRepository, IUnitOfWork uow)
        {
            _httpClientFactory = httpClientFactory;
            _userRepository = userRepository;
            _contactRepository = contactRepository;
            _locationRepository = locationRepository;
            _documentRepository = documentRepository;
            _uow = uow;
        }



        public async Task<bool> ImportRandomUsers()
        {
            HttpClient client = _httpClientFactory.CreateClient("RandomUserGeneratorApi");

            HttpResponseMessage httpResponse = await client.GetAsync("/api/1.4/?nat=br&results=100");

            if (!httpResponse.IsSuccessStatusCode) throw new Exception("Something went wrong calling the API");

            httpResponse.EnsureSuccessStatusCode();

            RadomUserApiResult result = await httpResponse.ReadContentAs<RadomUserApiResult>();



            foreach (var item in result.Results)
            {


                using var transaction = new CommittableTransaction(new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

                try
                {

                    User user = new User(item.Name.Title, $"{item.Name.First} {item.Name.Last}", item.Email, item.Login.UserName, item.Login.Sha256, item.Dob.Date, item.Picture.Medium);

                    await _userRepository.Save(user);

                    await _uow.SaveChangesAsync();

                    Contact contact = new Contact(item.Phone, item.Cell, user.Id);

                    Location location = new Location(item.Location.PostCode, item.Location.Country, item.Location.State, item.Location.City, item.Location.Street.Name, item.Location.Street.Number, item.Location.Coordinates.Latitude, item.Location.Coordinates.Longitude, user.Id, item.Location.TimeZone.Description, item.Location.TimeZone.OffSet);

                    Document document = new Document(item.Id.Name, item.Id.Value, user.Id);


                    await _contactRepository.Save(contact);
                    await _locationRepository.Save(location);
                    await _documentRepository.Save(document);

                    await _uow.SaveChangesAsync();

                    transaction.Commit();


                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return await Task.FromResult(false);
                }

            }

            return await Task.FromResult(true);
        }

      
    }
}
