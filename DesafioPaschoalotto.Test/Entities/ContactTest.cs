using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Validations;
using FluentAssertions;

namespace DesafioPaschoalotto.Test.Entities
{
    public class ContactTest
    {

        public static IEnumerable<object[]> BadContacts = new List<object[]>
        {
            new object[] { null , null, 1 },
            new object[] { string.Empty, string.Empty, 1 },
            new object[] { "" , null , 1},
            new object[] { null, "" , 1 },
            new object[] { "+55 (11) 4792-2341", "+55 (11) 98722-2341", 0 },
            new object[] { "+55 (11) 4792-2341", "+55 (11) 98722-2341", -1 },

        };


        [Theory]
        [InlineData("+55 (11) 4792-2341", "+55 (11) 98722-2341", 2)]
        public void  Contact_Should_Be_Construct_And_Valid(string phone, string cell, int userId)
        {

            Contact contact = new Contact(phone, cell, userId);

            contact.Cell.Should().Be(cell);
            contact.Phone.Should().Be(phone);
            contact.UserId.Should().Be(userId);
        }

        [Theory]
        [MemberData(nameof(BadContacts))]
        public void Contact_Constructor_Should_Throw_Domain_Exception(string phone, string cell, int userId)
        {
            Action action = () => new Contact(phone, cell, userId);
            action.Should().Throw<DomainValidationException>();
        }


        [Theory]
        [MemberData(nameof(BadContacts))]
        public void Contact_Validate_Should_Throw_Domain_Exception(string phone, string cell, int userId)
        {
            Contact contact = new Contact("+55 (11) 4792-2341", "+55 (11) 98722-2341", 2);
            Action action = () => contact.Validate(phone,cell,userId);
            action.Should().Throw<DomainValidationException>();
        }


        [Theory]
        [MemberData(nameof(BadContacts))]
        public void Contact_Update_Should_Throw_Domain_Exception(string phone, string cell, int userId)
        {
            Contact contact = new Contact("+55 (11) 4792-2341", "+55 (11) 98722-2341", 2);
            Action action = () => contact.Update(phone, cell, userId);
            action.Should().Throw<DomainValidationException>();
        }

        [Theory]
        [InlineData("+55 (11) 4192-2211", "+55 (11) 95422-2141", 104)]
        public void Contact_Should_Be_Updated(string phone, string cell, int userId)
        {
            Contact contact = new Contact("+55 (11) 4792-2341", "+55 (11) 98722-2341", 2);
            contact.Update(phone, cell, userId);
            contact.Cell.Should().Be(cell);
            contact.Phone.Should().Be(phone);
            contact.UserId.Should().Be(userId);
        }



    }
}
