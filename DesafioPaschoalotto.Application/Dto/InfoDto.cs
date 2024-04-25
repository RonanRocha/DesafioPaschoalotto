namespace DesafioPaschoalotto.Application.Dto
{
    public record InfoDto
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }
    }
}
