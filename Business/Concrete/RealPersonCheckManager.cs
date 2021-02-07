using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RealPersonCheckManager : IRealPersonCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            return false;// true
        }
    }
}
