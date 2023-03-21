using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class UserDTO
    {
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string Gender { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

       //add the colections after createing the other DTO's
    }

}

