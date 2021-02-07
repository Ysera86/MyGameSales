using Business.Abstract; 
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDAL _customerDAL;
        IRealPersonCheckService _realPersonCheck;
        public CustomerManager(ICustomerDAL customerDAL, IRealPersonCheckService realPersonCheck)
        {
            _customerDAL = customerDAL;
            _realPersonCheck = realPersonCheck;
        }

        public void AddCustomer(Customer customer)
        {
            if (_realPersonCheck.CheckIfRealPerson(customer))
            {
                _customerDAL.Add(customer); 
            }
            else
            {
                throw new Exception("Not a real person!");
            }
        }

        public void DeleteCustomer(Customer customer)
        {
            _customerDAL.Delete(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerDAL.GetEntities();
        }

        public Customer GetCustomer(int id)
        {
            return _customerDAL.GetEntity(c => c.Id == id);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerDAL.Update(customer);
        }
    }
}
