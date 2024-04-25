using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPaschoalotto.Application.ViewModels
{
    public class UserDetailViewModel  : UserViewModel
    {
        public ContactViewModel Contact { get; set; }
        public DocumentViewModel Document { get; set; }
        public LocationViewModel Location { get; set; }
    }
}
