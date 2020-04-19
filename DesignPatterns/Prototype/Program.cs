using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        public static void Main(string[] args)
        {
            Customer customer1 = new Customer { FirstName = "Mehmet", LastName = "Teker", City = "Van", id = 1 };

            Customer customer2 = (Customer)customer1.Clone();

            customer2.FirstName = "Fadime";

            Console.WriteLine("Customer1 : " + customer1.FirstName);
            Console.WriteLine("Customer2 : " + customer2.FirstName);
            Console.WriteLine("Customer2 : " + customer2.City);
            Console.ReadLine();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();

        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Employee:Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Customer:Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }


}
