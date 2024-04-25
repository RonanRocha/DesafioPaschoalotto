using DesafioPaschoalotto.Domain.Validations;

namespace DesafioPaschoalotto.Domain.Entities
{
    public class User
    {

        public User()
        {
            
        }

        public User(string title, string name, string email, string userName, string password, DateTime birthDate,  string imagePath)
        {
            Validate(title, name, email, userName, password, birthDate, imagePath);

            Title = title;
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
            BirthDate = birthDate;
            ImagePath = imagePath;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get;  private set; }
        public string ImagePath { get; private set; }
        public Contact Contact { get; set; }
        public Location Location { get; set; }
        public Document Document { get; set; }
       


        public void Update(string title, string name, string email, string userName, string password, DateTime birthDate, string imagePath)
        {
            Validate(title, name, email, userName, password, birthDate, imagePath);
            
            Title = title;
            Name = name;
            Email = email;
            UserName = userName;
            Password = password;
            BirthDate = birthDate;
            ImagePath = imagePath;

        }

        public void Validate(string title, string name, string email, string userName, string password, DateTime birthDate, string imagePath)
        {
            DomainValidationException.When(string.IsNullOrEmpty(title), $"{nameof(Title)} is required");
            DomainValidationException.When(title.Length > 10, $"{nameof(Title)} accept max 10 characters");
            DomainValidationException.When(string.IsNullOrEmpty(email), $"{nameof(Email)} is required");
            DomainValidationException.When(email.Length > 255, $"{nameof(Email)} accept max 255 characters");
            DomainValidationException.When(string.IsNullOrEmpty(name), $"{nameof(Name)} is required");
            DomainValidationException.When(name.Length > 255, $"{nameof(Name)} accept max 255 characters");
            DomainValidationException.When(name.Length < 3, $"{nameof(Name)} accept minimum 3 characters");
            DomainValidationException.When(string.IsNullOrEmpty(userName), $"{nameof(UserName)} is required");
            DomainValidationException.When(string.IsNullOrEmpty(email), $"{nameof(Email)} is required");
            DomainValidationException.When(string.IsNullOrEmpty(password), $"{nameof(Password)} is required");
            DomainValidationException.When(password.Length < 8, $"{nameof(Password)} accept minimum 8 characters");
            DomainValidationException.When(string.IsNullOrEmpty(imagePath), $"{nameof(ImagePath)} is required");


        }
    }
}
