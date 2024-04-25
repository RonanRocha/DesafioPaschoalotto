namespace DesafioPaschoalotto.Application.Dto
{
    public  record RadomUserApiResult
    {
        public List<UserDto> Results { get; set; }
        public InfoDto Info { get; set; }
    }
}
