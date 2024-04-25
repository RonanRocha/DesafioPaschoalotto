using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPaschoalotto.Application.ViewModels
{
    public class LocationViewModel
    {
        public int Id { get;  set; }
        public string PostCode { get;  set; }
        public string Country { get;  set; }
        public string State { get;  set; }
        public string City { get;  set; }
        public string Street { get;  set; }
        public int Number { get;  set; }
        public string Latitude { get;  set; }
        public string Longitude { get;  set; }
        public int UserId { get;  set; }
        public string TimeZone { get; set; }
        public string TimeZoneOffSet { get; set; }
    }
}
