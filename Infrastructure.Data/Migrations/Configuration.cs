namespace Infrastructure.Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Data.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Infrastructure.Data.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
           
            context.Categories.AddOrUpdate(s => s.Name, new Category[]{
                new Category
                {
                    Name = "Beverage",
                    Picture = @"c:\users\winnie\source\repos\Crown\WebApplication2\Contents\dairy.jpg",
                    Description = "The best collection dairy products in town"
                },
                new Category
                {
                    Name = "Sea Foods",
                    Picture = @" c:\users\winnie\source\repos\Crown\WebApplication2\Contents\seafoods.jpg",
                    Description = "Healthiest seafoods in the nation"
                },
               new Category
                {
                    Name = "Phones",
                    Picture = @" c:\users\winnie\source\repos\Crown\WebApplication2\Contents\phones.jpg",
                    Description = "Phones with great spec"
                }
            });
            context.SaveChanges();

            var Product1 = new Product
            {
                ProductName = "Milo",
                Category = context.Categories.Where(s=>s.Name=="Beverage").FirstOrDefault(),
                Price = 5400
            };


            var Product2 = new Product
            {
                ProductName = "Bournvita",
                Category = context.Categories.Where(s => s.Name == "Beverage").FirstOrDefault(),
                Price = 6800
            };

            var Product3 = new Product
            {
                ProductName = "Smoothie",
                Category = context.Categories.Where(s => s.Name == "Beverage").FirstOrDefault(),
                Price = 4000
            };
            var Product4 = new Product
            {
                ProductName = "Mackerel",
                Category = context.Categories.Where(s => s.Name == "Sea Foods").FirstOrDefault(),
                Price = 3500
            };
            var Product5 = new Product
            {
                ProductName = "Crab",
                Category = context.Categories.Where(s => s.Name == "Sea Foods").FirstOrDefault(),
                Price = 3200
            };
            var Product6 = new Product
            {
                ProductName = "Lenovo",
                Category = context.Categories.Where(s => s.Name == "Phones").FirstOrDefault(),
                Price = 68000
            };
            var Product7 = new Product
            {
                ProductName = "Infinix",
                Category = context.Categories.Where(s => s.Name == "Phones").FirstOrDefault(),
                Price = 40000
            };

            var p1 = new List<Product> { Product1, Product2, Product3, Product4, Product5, Product6, Product7 };

            context.Products.AddOrUpdate(s => s.ProductName, p1.ToArray());

            var Customers = new List<Customer>
            {
                new Customer
                {
                    LastName="Winifred", FirstName="Ofure", Address="17, NewYork Street, Canada", Phone="0706985856", DateAdded=DateTime.Now, Password="ofure"
                },
                new Customer
                {
                    LastName="Akinwumi", FirstName="Gerald", Address="89, Community Road, Akoka", Phone="0908859085", DateAdded=DateTime.Now, Password="gerald"
                },
                new Customer
                {
                    LastName="Nadia", FirstName="Grace", Address="9, Ade Street, Ilaje", Phone="070654040", DateAdded=DateTime.Now,Password="grace"
                },
                new Customer
                {
                    LastName="Kayla", FirstName="Rachael", Address="68, Loliu Street, Abuja", Phone="090684894", DateAdded=DateTime.Now,Password="rachael"
                },
                 new Customer
                {
                    LastName="Migan", FirstName="Justin", Address="58, Davidso Street, Yaba", Phone="0303484872", DateAdded=DateTime.Now,Password="justin"
                },
                 new Customer
                {
                    LastName="Layink", FirstName="Viola", Address="92, Ifeyinwa Strret, Yaba", Phone="0904637462", DateAdded=DateTime.Now,Password="viola"
                },
                  new Customer
                {
                    LastName="Landfy", FirstName="Chike", Address="Plot 41, Hrm Close, VI", Phone="0407862369", DateAdded=DateTime.Now,Password="chike"
                }
            };

            //context.Set<Customer>().AddRange(Customers);
            context.Customers.AddOrUpdate(s => s.Phone, Customers.ToArray());
            context.SaveChanges();

            var Order1 = new Order
            {

                ProductId = context.Products.Where(s => s.ProductName == "Mackerel").Select(s => s.Id).FirstOrDefault(),
                CustomerId = context.Customers.Where(s => s.Phone == "070654040").Select(s => s.Id).FirstOrDefault(),
                DateOrdered = DateTime.Now
            };
            var Order2 = new Order
            {
                ProductId = context.Products.Where(s=>s.ProductName=="Lenovo").Select(s=>s.Id).FirstOrDefault(),
                CustomerId = context.Customers.Where(s => s.Phone == "090684894").Select(s => s.Id).FirstOrDefault(),
                DateOrdered = DateTime.Now
            };
            var Order3 = new Order
            {

                ProductId = context.Products.Where(s => s.ProductName == "Bournvita").Select(s => s.Id).FirstOrDefault(),
                CustomerId = context.Customers.Where(s => s.Phone == "070654040").Select(s => s.Id).FirstOrDefault(),
                DateOrdered = DateTime.Now
            };
            var Order4 = new Order
            {

                ProductId = context.Products.Where(s => s.ProductName == "Smoothie").Select(s => s.Id).FirstOrDefault(),
                CustomerId = context.Customers.Where(s => s.Phone == "0706985856").Select(s => s.Id).FirstOrDefault(),
                DateOrdered = DateTime.Now
            };
            var Order5 = new Order
            {

                ProductId = context.Products.Where(s => s.ProductName == "Mackerel").Select(s => s.Id).FirstOrDefault(),
                CustomerId = context.Customers.Where(s => s.Phone == "0706985856").Select(s => s.Id).FirstOrDefault(),
                DateOrdered = DateTime.Now
            };
            var Order6 = new Order
            {

                ProductId = context.Products.Where(s => s.ProductName == "Infinix").Select(s => s.Id).FirstOrDefault(),
                CustomerId = context.Customers.Where(s => s.Phone == "0407862369").Select(s => s.Id).FirstOrDefault(),
                DateOrdered = DateTime.Now
            };
            var orders = new List<Order> { Order1, Order2, Order3, Order4, Order5, Order6 };
            context.Orders.AddOrUpdate(s => s.Id, orders.ToArray());

        }
    }
}
