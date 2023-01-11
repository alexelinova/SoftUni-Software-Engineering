namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public ICollection<CreateOrderItemViewModel> Items { get; set; }

        public ICollection<CreateOrderEmployeeViewModel> Employees { get; set; }
    }
}
