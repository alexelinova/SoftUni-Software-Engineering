using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Import
{
        public class ImportCustomerDto
        {
            public string Name { get; set; }
            public DateTime BirthDate { get; set; }
            public bool isYoungDriver { get; set; }
        }

}
