using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPaschoalotto.Application.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; private set; }
        public string Phone { get; private set; }
        public string Cell { get; private set; }
        public int UserId { get; private set; }
    }
}
