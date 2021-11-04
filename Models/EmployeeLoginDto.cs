using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankGateWay.Models
{
    public class EmployeeLoginDto
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string JwtToken { get; set; }
    }
}
