using DesafioPaschoalotto.Domain.Validations;

namespace DesafioPaschoalotto.Domain.Entities
{
    public class Location
    {
        public Location()
        {
            
        }

        public Location(object postCode,string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {

            Validate(postCode, country, state, city, street, number, latitude, longitude, userId,  timeZone,  timeZoneOffset);

            PostCode = postCode.ToString();
            Country = country;
            State = state;
            City = city;
            Street = street;
            Number = number;
            Latitude = latitude;
            Longitude = longitude;
            UserId = userId;
            TimeZone = timeZone;
            TimeZoneOffSet = timeZoneOffset;
        }

        public int Id { get; private set; }
        public string PostCode { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get;  private set; }
        public int UserId { get; private set; }
        public string TimeZone { get; set; }
        public string TimeZoneOffSet { get; set; }
        public User User { get; set; }
      


        public void Update(object postCode, string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {
             Validate(postCode, country, state, city, street, number, latitude, longitude, userId, timeZone, timeZoneOffset);

            PostCode = postCode.ToString();
            Country = country;
            State = state;
            City = city;
            Street = street;
            Number = number;
            Latitude = latitude;
            Longitude = longitude;
            UserId = userId;
            TimeZone = timeZone;
            TimeZoneOffSet = timeZoneOffset;

        }

        public void Validate(object postCode,string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {
            DomainValidationException.When(string.IsNullOrEmpty(country), $"{nameof(Country)}  is required");
            DomainValidationException.When(string.IsNullOrEmpty(state), $"{nameof(State)}  is required");
            DomainValidationException.When(string.IsNullOrEmpty(city), $"{nameof(City)} is required");
            DomainValidationException.When(string.IsNullOrEmpty(street), $"{nameof(Street)} is required");
            DomainValidationException.When(number <= 0, $"{nameof(Number)} accept only positive numbers");
            DomainValidationException.When(userId <= 0 , $"{nameof(UserId)} accept only positive numbers");
            DomainValidationException.When(postCode is null, $"{nameof(PostCode)} is required");
            DomainValidationException.When(string.IsNullOrEmpty(timeZone), $"{nameof(TimeZone)}  is required");
            DomainValidationException.When(string.IsNullOrEmpty(timeZoneOffset), $"{nameof(TimeZoneOffSet)}  is required");
            DomainValidationException.When(string.IsNullOrEmpty(latitude), $"{nameof(Latitude)}  is required");
            DomainValidationException.When(string.IsNullOrEmpty(longitude), $"{nameof(Longitude)}  is required");

        }

    }
}
