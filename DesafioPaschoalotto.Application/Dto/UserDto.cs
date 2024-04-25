namespace DesafioPaschoalotto.Application.Dto
{
    public record UserDto
    {
        public string Gender { get; set; }
        public NameDto Name { get; set; }
        public LocationDto Location { get; set; }
        public string Email { get; set; }
        public LoginDto Login { get; set; }
        public DateOfBirthDto Dob { get; set; }
        public RegisteredDto Registered { get; set; }
        public string Phone { get; set; }
        public string Cell { get; set; }
        public IdDto Id { get; set; }
        public PictureDto Picture { get; set; }
        public string Nat { get; set; }

    }
}
