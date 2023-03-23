using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.DTO
{
    public class MeasurementDTO
    {
        public decimal Height { get; set; }

        public decimal Weight { get; set; }

        public decimal Waist { get; set; }

        public decimal Bust { get; set; }

        public decimal Hip { get; set; }

        public string? Size { get; set; }

    }
}
