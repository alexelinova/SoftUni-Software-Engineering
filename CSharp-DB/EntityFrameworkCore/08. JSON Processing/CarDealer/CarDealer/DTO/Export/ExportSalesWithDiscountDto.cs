using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.DTO.Export
{
    public class ExportSalesWithDiscountDto
    {
        [JsonProperty("car")]
        public ExportSalesWithDiscountCarDto Car { get; set; }

        public string CustomerName { get; set; }

        public string Price { get; set; }

        public string Discount { get; set; }

        public string PriceWithDiscount { get; set; }
    }
}
