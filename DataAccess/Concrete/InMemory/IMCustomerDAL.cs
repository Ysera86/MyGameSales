using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class IMCustomerDAL : ICustomerDAL
    {
        List<Customer> _customers;
        public IMCustomerDAL()
        {
            _customers = new List<Customer>
            {
                new Customer{ Id=1, FirstName="Ad1", LastName="Soyad1", DateOfBirth= new DateTime(1982,1,1), NationalityId="15365678234", FavouriteGenre = "Horror"},
                new Customer{ Id=2, FirstName="Ad2", LastName="Soyad2", DateOfBirth= new DateTime(1983,5,12), NationalityId="22445678907", FavouriteGenre = "Romance"},
                new Customer{ Id=3, FirstName="Ad3", LastName="Soyad3", DateOfBirth= new DateTime(1994,12,21), NationalityId="97347658001", FavouriteGenre = "Horror, Comedy"},
                new Customer{ Id=4, FirstName="Ad4", LastName="Soyad4", DateOfBirth= new DateTime(1988,7,15), NationalityId="92653678901", FavouriteGenre = "Horror,Romance,Comedy"},
            };
        }
        public void Add(Customer entity)
        {
            _customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _customers.Remove(_customers.SingleOrDefault(x => x.Id == entity.Id));
        }

        public List<Customer> GetEntities(Expression<Func<Customer, bool>> filter = null)
        {
            return filter == null ? _customers :  _customers.Where(filter.Compile()).ToList();
        }

        public Customer GetEntity(Expression<Func<Customer, bool>> filter)
        {
            return _customers.SingleOrDefault(filter.Compile());
        }

        public void Update(Customer entity)
        {
            var customerToUpdate = _customers.SingleOrDefault(x => x.Id == entity.Id);

            customerToUpdate.FavouriteGenre = entity.FavouriteGenre;
        }
    }
}
