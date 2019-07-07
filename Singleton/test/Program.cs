using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton
{
    public class Program
    {
        public void Main(string[] args)
        {
            var _cus = CustomerManger.CreateAsSingleton();
            _cus.Save();

            var _cus2 = CustomerManger.CreateAsSingleton();
            _cus2.Save();

        }
    }

    class CustomerManger
    {
       private static CustomerManger _customerManger;
        static object _lockObject = new object();
       private CustomerManger()
       {
       
       }

        public static CustomerManger CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if(_customerManger == null)
                {
                    _customerManger = new CustomerManger(); 
                }
            }

            return _customerManger;
        }

        public void Save()
        {
            Console.WriteLine("Save!!");
        }

    }
}
