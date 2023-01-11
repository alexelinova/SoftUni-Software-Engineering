using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.DTO.Item
{
    public class ListAllItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
