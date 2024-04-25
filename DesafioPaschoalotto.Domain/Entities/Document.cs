using DesafioPaschoalotto.Domain.Validations;

namespace DesafioPaschoalotto.Domain.Entities
{
    public class Document
    {
        public Document()
        {
            
        }

        public Document(string type, string value, int userId)
        {
            Validate(type, value, userId); 
            
            Type = type;
            Value = value;
            UserId = userId;
        }

        public int Id { get; private set; }
        public string Type { get; private set; }
        public string Value { get; private set; }
        public int UserId { get; private set; }
        public User User { get; set; }

        public void Update(string type, string value, int userId)
        {
            Validate(type,value,userId);

            Type = type;
            Value = value;
            UserId = userId;
        }


        public void Validate(string type, string value, int userId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(type), $"{nameof(Type)} is required");
            DomainValidationException.When(type.Length > 10 , $"{nameof(Type)} accept max 10 characters");
            DomainValidationException.When(string.IsNullOrEmpty(value), $"{nameof(Value)} is required");
            DomainValidationException.When(userId <= 0 , $"{nameof(UserId)} accept only positive numbers");
        }


    }
}
