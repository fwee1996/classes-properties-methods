using System;
using System.Collections.Generic;

namespace Classes
{

    
//Class properties are the interface you provide to external code to get, and modify, the data stored inside the object.
    public class Customer
    {
        // Public Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsLocal { get; set; }

// Calculated property that has no setter. It is readonly.
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }

//Methods "function" are behaviors of your custom type that do something.
    public class DeliveryService
    {
        /*
          Properties
        */
        public string Name { get; set; }

        public string TransitType { get; set; }

        /*
          Methods
        */
        public void Deliver(Product product, Customer customer)
        {
            Console.WriteLine($"Product delivered by {TransitType} to {customer.FullName}");
        }
    }

    public class Product
    {
        /*
          Properties
        */
        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        /*
          Methods
        */
        public void Ship(Customer customer, DeliveryService service)
        {
            if (!customer.IsLocal)
            {
                service.Deliver(this, customer);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product tinkerToys = new Product()
            {
                Title = "Tinker Toys",
                Description = "You can build anything you want",
                Price = 32.49,
                Quantity = 25
            };

            Customer marcus = new Customer()
            {
                FirstName = "Marcus",
                LastName = "Fulbright",
                IsLocal = false
            };

            DeliveryService UPS = new DeliveryService()
            {
                Name = "UPS",
                TransitType = "train"
            };

            // Ship the tinker toys to Marcus using UPS
            tinkerToys.Ship(marcus, UPS);
        }
    }
}
