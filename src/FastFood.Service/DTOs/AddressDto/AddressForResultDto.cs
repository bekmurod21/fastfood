using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Service.DTOs.AddressDto
{
    public class AddressForResultDto
    {
        public long Id { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public int Home { get; set; }
    }
}
