using AutoMapper;
using DesafioPaschoalotto.Application.Dto;
using DesafioPaschoalotto.Application.Interfaces;
using DesafioPaschoalotto.Application.ViewModels;
using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Repositories;
using System.Data;

namespace DesafioPaschoalotto.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork uow) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;

        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<IEnumerable<UserViewModel>>(users);

        }

        public async Task UpdateUser(UpdateUserDto updateUserDto)
        {
            User? user = await _userRepository.GetDetailedUserById(updateUserDto.Id);

            if (user == null) throw new ApplicationException("user not found");

            user.Update(
                updateUserDto.Title,
                updateUserDto.Name,
                updateUserDto.Email,
                updateUserDto.UserName,
                updateUserDto.Password,
                updateUserDto.BirthDate,
                updateUserDto.ImagePath
            );

            user.Contact.Update(
                updateUserDto.Phone,
                updateUserDto.Cell,
                user.Id
            );

            user.Document.Update(
                updateUserDto.DocumentType,
                updateUserDto.DocumentValue,
                user.Id
            );

            user.Location.Update(
                updateUserDto.PostCode,
                updateUserDto.Country,
                updateUserDto.State,
                updateUserDto.City,
                updateUserDto.Street,
                updateUserDto.Number,
                updateUserDto.Latitude,
                updateUserDto.Longitude,
                user.Id,
                updateUserDto.TimeZone,
                updateUserDto.TimeZoneOffset
            );

            await _userRepository.Update(user);
            await _uow.SaveChangesAsync();

            await Task.CompletedTask;


        }

        public async Task<UserDetailViewModel> GetUserDetailById(int id)
        {
            var user = await _userRepository.GetDetailedUserById(id);
            return _mapper.Map<UserDetailViewModel>(user);
        }

        public async Task<DataTable> GetUsersToReport()
        {
            var users = await _userRepository.GetAllUsersDetailed();

            if (users == null || users.Count() <= 0) throw new ApplicationException("Users not found");

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("BirthDate");
            dataTable.Columns.Add("Document");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("Cell");

            foreach (var user in users)
            {
                dataTable.Rows.Add(user.Id, user.Name, user.Email, user.BirthDate, $"{user.Document.Type} : {user.Document.Value}", user.Contact.Phone, user.Contact.Cell);
            }


            return dataTable;
        }
    }
}
