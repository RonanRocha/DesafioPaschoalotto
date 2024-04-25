using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Validations;
using FluentAssertions;

namespace DesafioPaschoalotto.Test.Entities
{
    public class DocumentTest
    {

        public static IEnumerable<object[]> BadDocuments = new List<object[]>
        {
            new object[] { "NOVOTIPODEDOCUMENTOCOMMAISDE10CARACTERES", "4678953325", 2 },
            new object[] { "CPF", "36635548784", -1 },
            new object[] { "CPF", "36635548784", 0 },
            new object[] { "CPF", "", 23},
            new object[] { null, "36635548784", 1},
            new object[] { null, null, 1 },
            new object[] { "RG", null, 1},

        };

        [Theory]
        [InlineData("RG",  "4678953325", 2)]
        [InlineData("CPF", "36635548784", 1)]
        public void Document_Should_Be_Construct(string type, string value, int userId)
        {
            Document document = new Document(type, value, userId);

            document.Type.Should().Be(type);
            document.Value.Should().Be(value);
            document.UserId.Should().Be(userId);

        }

        [Theory]
        [MemberData(nameof(BadDocuments))]
        public void Document_Should_Be_Throw_Exception_On_Construct(string type, string value, int userId)
        {
           Action action = () => new Document(type, value, userId);
           action.Should().Throw<DomainValidationException>();

        }


        [Theory]
        [MemberData(nameof(BadDocuments))]
        public void Document_Should_Be_Throw_Exception_On_Updated(string type, string value, int userId)
        {
            Document document = new Document();
            Action action = () => document.Update(type,value,userId);
            action.Should().Throw<DomainValidationException>();

        }


        [Theory]
        [MemberData(nameof(BadDocuments))]
        public void Document_Should_Be_Throw_Exception_On_Validate(string type, string value, int userId)
        {
            Document document = new Document();
            Action action = () => document.Validate(type, value, userId);
            action.Should().Throw<DomainValidationException>();
        }


        [Theory]
        [InlineData("RG", "4678953325", 2)]
        [InlineData("CPF", "36635548784", 1)]
        public void Document_Should_Be_Updated(string type, string value, int userId)
        {
            Document document = new Document();
            document.Update(type, value, userId);

            document.Type.Should().Be(type);
            document.Value.Should().Be(value);
            document.UserId.Should().Be(userId);
        }





    }
}
