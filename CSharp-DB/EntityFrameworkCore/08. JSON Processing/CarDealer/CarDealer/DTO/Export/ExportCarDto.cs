using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Export
{
    public class ExportCarDto
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public string Make { get; set; }

        public long TravelledDistance { get; set; }
    }
}
