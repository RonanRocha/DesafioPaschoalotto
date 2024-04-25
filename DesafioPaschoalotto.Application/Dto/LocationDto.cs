namespace DesafioPaschoalotto.Application.Dto
{
    public record LocationDto
    {
        public StreetDto Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public object PostCode { get; set; }
        public CoordinatesDto Coordinates { get; set; }
        public TimeZoneDto TimeZone { get; set; }
    }
}
