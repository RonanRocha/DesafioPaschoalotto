using DesafioPaschoalotto.Domain.Validations;

namespace DesafioPaschoalotto.Domain.Entities
{
    public class Contact
    {
        public Contact()
        {
            
        }

        public Contact(string phone, string cell, int userId)
        {
            Validate(phone, cell, userId);

            Phone = phone;
            Cell = cell;
            UserId = userId;
        }

        public int Id { get; private set; }
        public string Phone { get; private set; }
        public string Cell { get; private set; }
        public int UserId { get; private set; }
        public User User { get;  set; }

        public void Update(string phone, string cell, int userId)
        {
            Validate(phone, cell, userId);

            Phone = phone;
            Cell = cell;
            UserId = userId;
        }


        public void Validate(string phone, string cell, int userId)
        {
            DomainValidationException.When(string.IsNullOrEmpty(phone), $"{nameof(Phone)} is required");
            DomainValidationException.When(string.IsNullOrEmpty(cell), $"{nameof(Cell)} is required");
            DomainValidationException.When(userId <= 0 , $"{nameof(UserId)} accept only positive number");
        }


    }
}
