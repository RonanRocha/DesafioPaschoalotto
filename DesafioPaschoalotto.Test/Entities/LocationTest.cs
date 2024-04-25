using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Validations;
using FluentAssertions;

namespace DesafioPaschoalotto.Test.Entities
{
    public class LocationTest
    {

        public static IEnumerable<object[]> BadLocations = new List<object[]>
        {
            new object[] { "0", "", null , "T", "Rua Luiz Jose Da Paixao", -46, "", string.Empty, 0 , "", ""},
            new object[] { null, "Teste", string.Empty , "", "", -46, "", string.Empty, -1 , "", ""},
            new object[] { "06767-351", null, null , null, "Rua Luiz Jose Da Paixao", -46, "", string.Empty, 0 , "", ""},
            new object[] { "06767-351", "", "" , "", null, -46, "", string.Empty, 0 , "", ""},
            new object[] { "1", "", "" , "", null, -46, "", string.Empty, 0 , null, null},

        };


        [Theory]
        [InlineData("06786-000", "Brazil", "São Paulo", "Taboão da Serra", "Rua Luiz Jose Da Paixao", 46, "-23.630716511071412", "-46.80950195362185", 2, "São Paulo, Brazil", "+3:00")]
        public void Location_Should_Be_Construct(string postCode, string country,string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {
            Location location = new Location(postCode,country, state,city,street,number,latitude,longitude, userId,timeZone,timeZoneOffset);
            
            location.PostCode.Should().Be(postCode);
            location.Country.Should().Be(country);
            location.State.Should().Be(state);
            location.City.Should().Be(city);
            location.Street.Should().Be(street);
            location.Number.Should().Be(number);
            location.Latitude.Should().Be(latitude);    
            location.Longitude.Should().Be(longitude);
            location.UserId.Should().Be(userId);    
            location.TimeZone.Should().Be(timeZone);
            location.TimeZoneOffSet.Should().Be(timeZoneOffset);
        }


        [Theory]
        [InlineData("06786-000", "Brazil", "São Paulo", "Taboão da Serra", "Rua Luiz Jose Da Paixao", 46, "-23.630716511071412", "-46.80950195362185", 2, "São Paulo, Brazil", "+3:00")]
        public void Location_Should_Be_Updated(string postCode, string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {
            Location location = new Location();

            location.Update(postCode, country, state, city, street,number,latitude,longitude,userId,timeZone,timeZoneOffset);

            location.PostCode.Should().Be(postCode);
            location.Country.Should().Be(country);
            location.State.Should().Be(state);
            location.City.Should().Be(city);
            location.Street.Should().Be(street);
            location.Number.Should().Be(number);
            location.Latitude.Should().Be(latitude);
            location.Longitude.Should().Be(longitude);
            location.UserId.Should().Be(userId);
            location.TimeZone.Should().Be(timeZone);
            location.TimeZoneOffSet.Should().Be(timeZoneOffset);
        }

        [Theory]
        [MemberData(nameof(BadLocations))]
        public void Location_Should_Throw_Exception(string postCode, string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {

            Action a = () =>  new Location(postCode,country, state, city, street, number, latitude, longitude, userId, timeZone,timeZoneOffset);
            a.Should().Throw<DomainValidationException>();
        }


        [Theory]
        [MemberData(nameof(BadLocations))]
        public void Location_Update_Should_Throw_Exception(string postCode, string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {
            Location location = new Location();
            Action a = () => location.Update(postCode,country,state,city,street,number,latitude,longitude,userId,timeZone,timeZoneOffset);
            a.Should().Throw<DomainValidationException>();
        }


        [Theory]
        [MemberData(nameof(BadLocations))]
        public void Location_Validate_Should_Throw_Exception(string postCode, string country, string state, string city, string street, int number, string latitude, string longitude, int userId, string timeZone, string timeZoneOffset)
        {
            Location location = new Location();
            Action a = () => location.Validate(postCode, country, state, city, street, number, latitude, longitude, userId, timeZone, timeZoneOffset);
            a.Should().Throw<DomainValidationException>();
        }

    }
}