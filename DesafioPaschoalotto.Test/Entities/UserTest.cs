using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Validations;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPaschoalotto.Test.Entities
{
    public class UserTest
    {

        public static IEnumerable<object[]> Users = new List<object[]>
        {
            new object[] { "Mr", "Fulano de tal", "fulano@email.com", "username", "stronglyPass@#123", new DateTime(1990, 07, 12) , "image.png"},
        };

        public static IEnumerable<object[]> BadUsers = new List<object[]>
        {
            new object[] { "Mrs", "Fu", "fulano@email.com", "username", "stronglyPass@#123", new DateTime(1990, 07, 12) , "image.png"},
            new object[] { "Mrs", "Fulano de tal", "", "username", "stronglyPass@#123", new DateTime(1990, 07, 12) , "image.png"},
            new object[] { "Mrs", "Fulano de tal", "fulano@email.com", "", "stronglyPass@#123", new DateTime(1990, 07, 12) , "image.png"},
            new object[] { "Mrs", "Fulano de tal", "fulano@email.com", "username", "23", new DateTime(1990, 07, 12) , "image.png"},
            new object[] { "Mrs", "Fulano de tal", "fulano@email.com", "username", "23", null , "image.png"},
            new object[] { "Mrs", "Fulano de tal", "fulano@email.com", "username", "23", new DateTime(1990, 07, 12) , ""},
            new object[] { "", "Fulano de tal", "fulano@email.com", "username", "23", new DateTime(1990, 07, 12) , null},
            new object[] { null, "Fulano de tal", "fulano@email.com", "username", "23", new DateTime(1990, 07, 12) , "image.png"},
            new object[] { "Mrs com string muito grande", "Fulano de tal", "fulano@email.com", "username%$asda98", "23281377@09as9", new DateTime(1990, 07, 12) , "image.png"},
        };

        [Theory]
        [MemberData(nameof(Users))]
        public void User_Should_Be_Construct(string title, string name, string email, string userName, string password, DateTime date, string imagePath)
        {
            User user = new User(title,name,email,userName,password,date,imagePath);
            user.Title.Should().Be(title);
            user.Name.Should().Be(name);
            user.Email.Should().Be(email);
            user.UserName.Should().Be(userName);
            user.Password.Should().Be(password);
            user.BirthDate.Should().Be(date);
            user.ImagePath.Should().Be(imagePath);
            
        }

        [Theory]
        [MemberData(nameof(BadUsers))]
        public void User_Should_Be_Throw_Exception_On_Construnct(string title, string name, string email, string userName, string password, DateTime date, string imagePath)
        {
            Action action = () => new User(title, name, email, userName, password, date, imagePath);
            action.Should().Throw<DomainValidationException>();
         
        }


        [Theory]
        [MemberData(nameof(BadUsers))]
        public void User_Should_Be_Throw_Exception_On_Updated(string title, string name, string email, string userName, string password, DateTime date, string imagePath)
        {
            User user = new User();
            Action action = () => user.Update(title, name, email, userName, password, date, imagePath);
            action.Should().Throw<DomainValidationException>();

        }

        [Theory]
        [MemberData(nameof(BadUsers))]
        public void User_Should_Be_Throw_Exception_On_Validate(string title, string name, string email, string userName, string password, DateTime date, string imagePath)
        {
            User user = new User();
            Action action = () => user.Validate(title, name, email, userName, password, date, imagePath);
            action.Should().Throw<DomainValidationException>();

        }


        [Theory]
        [MemberData(nameof(Users))]
        public void User_Should_Be_Updated(string title, string name, string email, string userName, string password, DateTime date, string imagePath)
        {
            User user = new User();
            user.Update(title,name,email,userName,password,date,imagePath);
            user.Title.Should().Be(title);
            user.Name.Should().Be(name);
            user.Email.Should().Be(email);
            user.UserName.Should().Be(userName);
            user.Password.Should().Be(password);
            user.BirthDate.Should().Be(date);
        

        }

    }
}
