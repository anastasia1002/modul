using System;

namespace Module_Nastya
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] allProducts = new Product[3] { new Product("product1", 2, 150), 
                new Product("product2", 2, 200), new Product("product3", 1, 300)};
            Order order1 = new Order();
            order1.OrderDate = new DateTime(2021, 4, 2);
            order1.OrderDelivery = new Delivery("Вiддiлення 1");
            order1.OrderCustomer = new Customer("098987612", "test@gmai.com", "Vasya", "jwt");
            order1.AllProducts = allProducts;

            
            // Виконати поверхневе копіювання o1 і присвоїти її o2
            Order o2 = order1.ShallowCopy();
            
            // Виконати глибоке копіювання o1 і присвоїти її o3
            Order o3 = order1.DeepCopy();

            // Вивід o1,o2,o3
            Console.WriteLine("Original values of o1, o2, o3:");
            Console.WriteLine("   o1 instance values: ");
            Console.WriteLine(order1);
            Console.WriteLine("   o2 instance values:");
            Console.WriteLine(o2);
            Console.WriteLine("   o3 instance values:");
            Console.WriteLine(o3);

            
            // Змінити значення властивостей order1 i відобразити o1, o2, o3
            order1.OrderDate = new DateTime(2021, 5, 11); ;
            order1.OrderDelivery = new Delivery("Вiддiлення 5");
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   o1 instance values: ");
            Console.WriteLine(order1);
            Console.WriteLine("   o2 instance values (reference values have changed):");
            Console.WriteLine(o2);
            Console.WriteLine("   o3 instance values (everything was kept the same):");
            Console.WriteLine(o3);
        }
        public class Order
        {
            public DateTime OrderDate;
            public Delivery OrderDelivery;
            public Customer OrderCustomer;
            public Product[] AllProducts;


            public Order ShallowCopy()
            {
                return (Order)this.MemberwiseClone();
            }

            public Order DeepCopy()
            {
                Order clone = (Order)this.MemberwiseClone();
                clone.OrderDelivery = new Delivery(OrderDelivery.DeliveryInfo);
                return clone;
            }
            public override string ToString()
            {
                return $" Date: {OrderDate}, Delivery: {OrderDelivery}, Customer: {OrderCustomer}, Products: {AllProducts}"; 
            }
        }

        public class Delivery
        {
            public string DeliveryInfo;
            public Delivery(string info)
            {
                this.DeliveryInfo = info;
            }
            public override string ToString()
            {
                return $"Info: {DeliveryInfo}";
            }
        }

        public class Customer
        {
            public string PhoneNumber;
            public string Email;
            public string Name;
            public string Jwt;
            public Customer(string ph, string em, string n, string j)
            {
                this.PhoneNumber = ph;
                this.Email = em;
                this.Name = n;
                this.Jwt = j;
            }
            public override string ToString()
            {
                return $"Phone: {PhoneNumber}, Email: {Email}, Name: {Name}, JWT: {Jwt}";
            }
        }

        public class Product
        {
            public string Description;
            public int Quantity;
            public double Price;
            public Product(string d, int q, double p)
            {
                this.Description = d;
                this.Quantity = q;
                this.Price = p;
            }
            public override string ToString()
            {
                return $"Description: {Description}, Quantity: {Quantity}, Price: {Price}";
            }
        }
        

    }

    
}
