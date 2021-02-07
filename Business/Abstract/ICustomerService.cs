using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomer(int id);
        void AddCustomer(Customer Customer);
        void UpdateCustomer(Customer Customer);
        void DeleteCustomer(Customer Customer);
    }
}
