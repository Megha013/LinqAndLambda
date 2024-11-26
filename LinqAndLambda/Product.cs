using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqAndLambda
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string CompanyName { get; set; }
        //public override string ToString()
        //{
        //    return $"Id: {Id}, Name: {Name}, Price: {Price}, CompanyName: {CompanyName}";
        //}
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product{Id=1,Name="Mouse",Price=799,CompanyName="Dell"},
                new Product{Id=2,Name="Mouse",Price=699,CompanyName="Lenovo"},
                new Product{Id=3,Name="Laptop",Price=34799,CompanyName="Dell"},
                new Product{Id=4,Name="Laptop",Price=45699,CompanyName="Sony"},
                new Product{Id=5,Name="Laptop",Price=38799,CompanyName="Lenovo"},
                new Product{Id=6,Name="Keyboard",Price=599,CompanyName="Dell"},
                new Product{Id=7,Name="Keyboard",Price=999,CompanyName="Microsoft"},
                new Product{Id=8,Name="RAM 4GB",Price=2799,CompanyName="Corsair"},
                new Product{Id=9,Name="Speaker",Price=5799,CompanyName="Sony"},
                new Product{Id=10,Name="USB Mouse",Price=1299,CompanyName="Microsoft"},

            };
           
            //Using LINQ query
            //1.All products using LINQ query
            var res1 = from p in products
                       select p;
            Console.WriteLine("1. Display all products : ");
            foreach (var p in res1)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //2.products price is greater than 1500
            var res2 = from p in products
                       where p.Price > 1500
                       select p;
            Console.WriteLine("2. products price is greater than 1500 : ");
            foreach (var p in res2)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //3.Display products whose price is in between 10000 to 40000
            var res3 = from product in products
                       where product.Price >= 10000 && product.Price <= 40000
                       select product;
            Console.WriteLine("3. products whose price is in between 10000 to 40000 : ");
            foreach (var p in res3)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //4.Display products of Dell company
            var res4 = from p in products
                       where p.CompanyName == "Dell"
                       select p;
            Console.WriteLine("4. products of Dell company : ");
            foreach (var p in res4)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //5.Display all company laptops
            var res5 = from p in products
                       where p.Name == "Laptop"
                       select p;
            Console.WriteLine("5. all company laptops : ");
            foreach (var p in res5)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //6.Display products whose company name start with ‘M’
            var res6 = from p in products
                       where p.CompanyName.StartsWith("M")
                       select p;
            Console.WriteLine("6. products whose company name start with ‘M’ : ");
            foreach (var p in res6)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //7.Display all company mouse whose price is less than 1000
            var res7 = from p in products
                       where p.Name == "Mouse" && p.Price < 1000
                       select p;
            Console.WriteLine("7. all company mouse whose price is less than 1000 : ");
            foreach (var p in res7)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //8.Display all products descending order by their price
            var res8 = from p in products
                       orderby p.Price descending
                       select p;
            Console.WriteLine("8. all products descending order by their price : ");
            foreach (var p in res8)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //9.Display all products accessing order by their company name
            var res9 = from p in products
                       orderby p.CompanyName
                       select p;
            Console.WriteLine("9. all products accessing order by their company name : ");
            foreach (var p in res9)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //10.Display all keyboards accessing order by their price
            var res10 = from p in products
                        where p.Name == "Keyboard"
                        orderby p.Price
                        select p;
            Console.WriteLine("10. all keyboards accessing order by their price : ");
            foreach (var p in res10)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();


            //Using Lambda Expressions
            //1.Display all products descending order by their price
            var ress1 = products.OrderByDescending(x => x.Price).ToList();
            Console.WriteLine("1. all products descending order by their price: ");
            foreach (var p in ress1)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //2.Display product whose Id is 5
            var ress2 = products.Where(x => x.Id == 5);
            Console.WriteLine("2. product whose Id is 5 : ");
            foreach (var p in ress2)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //3.Display all products whose price less than 5000
            var ress3 = products.Where(x => x.Price < 5000).ToList();
            Console.WriteLine("3. all products whose price less than 5000 : ");
            foreach (var p in ress3)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //4.Display 3 products which have maximum price
            var ress4 = products.OrderByDescending(x => x.Price).Take(3).ToList();
            Console.WriteLine("4. 3 products which have maximum price : ");
            foreach (var p in ress4)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

            //5.Display 5 products which have minimum price
            var ress5 = products.OrderBy(x => x.Price).Take(5).ToList();
            Console.WriteLine("5. 5 products which have minimum price : ");
            foreach (var p in ress5)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}, Company: {p.CompanyName}, Price: {p.Price}");
            }
            Console.WriteLine();

        }
    }
}
