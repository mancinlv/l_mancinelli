using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class Program
    {
        /* Practice your LINQ!
         * You can use the methods in Data Loader to load products, customers, and some sample numbers
         * 
         * NumbersA, NumbersB, and NumbersC contain some ints
         * 
         * The product data is flat, with just product information
         * 
         * The customer data is hierarchical as customers have zero to many orders
         */

        private static void Main()
        {
            //PrintOutOfStock();
            //UnitCoseThree();
            //Washington();
            //ProductNames();
            //Increase25();
            //Uppers();
            //Evens();
            //SomeProducts();
            ALessThanB();
            //LessThan500();
            //ElementsInA();
            //ThreeInWash();
            //Skip3();
            //AllBut2();
            //GreaterThan6();
            //LessThanIndex();
            //DivisibleBy3();
            //AlphabeticOrderC();
            //DecendingStock();
            //SortProducts();
            //ReverseC();
            //RemainederOf5();
            //ProductsCategory();
            //ProductYearMonth();
            //UniqueNames();
            //UniqueAUniqueB();
            //SharedAB();
            //OnlyInA();
            //Product12();
            //Product789();
            //ProductOutOfStock();
            //LessThan9();
            //AllInStock();
            //OddsInA();
            //CountOrders();
            //CountProducts();
            //InStock();
            //LowestPriced();
            //HighestPriced();
            //AveragePrice();
            //CharacterCouting();

            Console.ReadLine();
        }

        //// 1
        //private static void PrintOutOfStock()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var results = products.Where(p => p.UnitsInStock == 0);

        //    foreach (var product in results)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}

        //// 2
        //private static void UnitCoseThree()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var results = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);

        //    foreach (var product in results)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}

        ////3
        //private static void Washington()
        //{
        //    var customers = DataLoader.LoadCustomers();

        //    var results = customers.Where(c => c.Region == "WA");

        //    foreach (var customerWA in results)
        //    {
        //        Console.WriteLine("\n{0}\n", customerWA.CompanyName);

        //        for (int i = 0; i< customerWA.Orders.Length; i++)
        //        {
        //            Console.WriteLine("  {0}", customerWA.Orders[i].OrderID);
        //        }
        //    }
        //}

        //// 4
        //private static void ProductNames()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var results = from p in products
        //                  select new {allProducts = p.ProductName};

        //    Console.WriteLine("{0}", results.ToString());
        //    foreach (var r in results)
        //    {
        //        Console.WriteLine("{0}", r.allProducts);
        //    }
        //}

        //// 5
        ////Create a new sequence of products and unit prices where the unit prices are increased by 25%.
        //private static void Increase25()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var results = from p in products
        //        select new {p.ProductName, UnitPrice=p.UnitPrice*1.25M};

        //    Console.WriteLine("0", results.ToString());
        //    foreach (var r in results)
        //    {
        //        Console.WriteLine("{0} ---> {1}", r.ProductName, r.UnitPrice);
        //    }
        //}

        //// 6
        ////Create a new sequence of just product names in all upper case.
        //private static void Uppers()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var results = from p in products
        //        select new {productUP = p.ProductName.ToUpper()};
        //    foreach (var r in results)
        //    {
        //        Console.WriteLine(r.productUP);
        //    }
        //}

        ////7
        //// Create a new sequence with products with even numbers of units in stock.
        //private static void Evens()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var evenUnits = from i in products
        //        where i.UnitPrice%2 == 0
        //        select i;
        //    foreach (var i in evenUnits)
        //    {
        //        Console.WriteLine(i.ProductName);
        //    }
        //}

        ////8
        ////Create a new sequence of products with ProductName, Category, and rename UnitPrice to Price.
        //private static void SomeProducts()
        //{
        //    var products = DataLoader.LoadProducts();

        //    var toPrice = from p in products
        //                  select new { p.ProductName, p.Category, Price = p.UnitPrice };

        //    foreach (var product in toPrice)
        //    {
        //        Console.WriteLine("\n{0,-5}:  {1:D2}---> {2}", product.ProductName, product.Category, product.Price);
        //    }
        //}

        //9
        //(arrays B & C) Make a query that returns all pairs of numbers from both arrays such that the number from numbersB is less than the number from numbersC.
        private static void ALessThanB() //ZIP
        {
            int[] arrays = DataLoader.NumbersB;
            int[] arrays2 = DataLoader.NumbersC;

            var paris = arrays.Zip(arrays2, (a, b) => (a < b));
            Console.WriteLine("When a is less than b:");
            foreach (var p in paris)
            {
                Console.WriteLine(p);
            }
        }

        // 10
        // Select CustomerID, OrderID, and Total where the order total is less than 500.00.
        //private static void LessThan500()
        //{
        //    List<Customer> customers = DataLoader.LoadCustomers();

        //    var orders = from c in customers
        //        from o in c.Orders
        //        where o.Total < 500.00M
        //        select new {c.CustomerID, o.OrderID, o.Total};
        //    foreach (var order in orders)
        //    {
        //        Console.WriteLine("Customer: {0} w/ ID {1}  spent  {2}", order.CustomerID, order.OrderID, order.Total);
        //    } 

        //}

        //// 11
        ////Write a query to take only the first 3 elements from NumbersA.

        //private static void ElementsInA()
        //{
        //    int[] array = DataLoader.NumbersA;

        //    var first3 = array.Take(3);

        //    foreach (int str in first3)
        //    {
        //        Console.WriteLine(str);
        //    }

        //}

        ////12
        ////Get only the first 3 orders from customers in Washington.
        //private static void ThreeInWash()
        //{
        //    List<Customer> customers = DataLoader.LoadCustomers();

        //    var order = (from c in customers
        //        from o in c.Orders
        //        where c.Region == "WA"
        //        select new {c.CustomerID, o.OrderID, o.OrderDate})
        //        .Take(3);
        //    foreach (var threeWA in order)
        //    {
        //        Console.WriteLine(threeWA);
        //    }

        //}

        ////13
        ////Skip the first 3 elements of NumbersA
        //public static void Skip3()
        //{
        //    int[] array = DataLoader.NumbersA;
        //    var skipThree = array.Skip(3);
        //    foreach (var skip in skipThree)
        //    {
        //        Console.WriteLine(skip);
        //    }
        //}

        ////14
        ////Get all except the first two orders from customers in Washington.

        //public static void AllBut2()
        //{
        //    List<Customer> customers = DataLoader.LoadCustomers();
        //    var order = from c in customers
        //        from o in c.Orders
        //        where c.Region == "WA"
        //        select new {c.CustomerID, o.OrderID, o.OrderDate};

        //    var allButFirst = order.Skip(2);
        //    foreach (var var in allButFirst)
        //    {
        //        Console.WriteLine(var);
        //    }

        //}

        //// 15
        ////Get all the elements in NumbersC from the beginning until an element is greater or equal to 6.
        //private static void GreaterThan6()
        //{
        //    int[] array = DataLoader.NumbersC;
        //    var firstLessThan6 = array.TakeWhile(a => a < 6);
        //    foreach (var v in firstLessThan6)
        //    {
        //        Console.WriteLine(v);
        //    }
        //}

        ////16
        ////Return elements starting from the beginning of NumbersC until a number is hit that is less than its position in the array.
        //private static void LessThanIndex()
        //{
        //    int[] array = DataLoader.NumbersC;
        //    var cIndexLess = array.TakeWhile((a, index) => a >= index);
        //    foreach (var i in cIndexLess)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}

        ////17
        ////Return elements from NumbersC starting from the first element divisible by 3.
        //private static void DivisibleBy3()
        //{
        //    int[] array = DataLoader.NumbersC;
        //    var cBy3 = array.SkipWhile(a => a%3 != 0);
        //    foreach (var v in cBy3)
        //    {
        //        Console.WriteLine(v);
        //    }
        //}

        //18
        //Order products alphabetically by name. 
        private static void AlphabeticOrderC()
        {
            var products = DataLoader.LoadProducts();
            var ordersInOrder = products.OrderBy(p => p.ProductName);
            foreach (var product in ordersInOrder)
            {
                Console.WriteLine(product.ProductName);
            }
            
        }
        
        ////19
        ////Order products by UnitsInStock descending.
        //private static void DecendingStock()
        //{
        //    var products = DataLoader.LoadProducts();
        //    var decendingUnits = from p in products
        //        orderby p.UnitsInStock descending 
        //        select new {p.ProductName, p.UnitsInStock};
        //    foreach (var i in decendingUnits)
        //    {
        //        Console.WriteLine("{0} -- {1}", i.ProductName, i.UnitsInStock);
        //    }
        //}

        ////20
        ////Sort the list of products, first by category, and then by unit price, from highest to lowest.
        //private static void SortProducts()
        //{
        //    var products = DataLoader.LoadProducts();
        //    var productByCatByPrice = from p in products
        //        orderby p.Category, p.UnitPrice descending
        //        select new{p.ProductName, p.Category, p.UnitPrice};
        //    foreach (var v in productByCatByPrice)
        //    {
        //        Console.WriteLine("\n{0} --> {1} --> {2}", v.ProductName, v.Category, v.UnitPrice);
        //    }
        //}

        //21 
        //Reverse NumbersC.  
        public static void ReverseC()
        {
            int[] array = DataLoader.NumbersC;
            var reverseC = array.Reverse();

            foreach (var v in reverseC)
            {
                Console.WriteLine(v);
            }

        }

        //22 
        //Display the elements of NumbersC grouped by their remainder when divided by 5.
        public static void RemainederOf5()
        {
            int[] array = DataLoader.NumbersC;
            var remainder5ofC = from a in array
                group a by a%5
                into g
                select new {Remainder = g.Key, Numbers = g};
            foreach (var v in remainder5ofC)
            {
                Console.WriteLine("numbers with remainder {0}:", v.Remainder);
                foreach (var p in v.Numbers)
                {
                    Console.WriteLine(p);
                }

            }

        }

        //23
        //Display products by Category.

        public static void ProductsCategory()
        {
            var products = DataLoader.LoadProducts();
            var categoryofP = from p in products
                group p by p.Category
                into g
                select new {Categories = g.Key, Products = g};
            foreach (var group in categoryofP)
            {
                Console.WriteLine("\nProducts in {0}\n", group.Categories);
                foreach (var product in group.Products)
                {
                    Console.WriteLine("{0}", product.ProductName);
                }

            }
        }

        //24
        // Group customer orders by year, then by month.
        public static void ProductYearMonth()
        {
            List<Customer> customers = DataLoader.LoadCustomers();

            var customerByYear = from c in customers

                select
                    new
                    {
                        c.CompanyName,
                        YearGroups =
                            from o in c.Orders
                            group o by o.OrderDate.Year
                            into YearGroup
                            select
                                new
                                {
                                    Year = YearGroup.Key,
                                    MonthGroups =
                                        from o in YearGroup
                                        group o by o.OrderDate.Month
                                        into MonthGroup
                                        select new {Month = MonthGroup.Key, Orders = MonthGroup}
                                }
                    };

            foreach (var order in customerByYear)
            {
                Console.Write("\n {0}\n", order.CompanyName);
                foreach (var year in order.YearGroups)
                {
                    Console.WriteLine(year.Year);
                    foreach (var month in year.MonthGroups)
                    {
                        Console.WriteLine(month.Month);
                    }

                }
            }

        }

        //25
        //Create a list of unique product category names
        public static void UniqueNames()
        {
            var product = DataLoader.LoadProducts();
            var uinque = (from p in product
                select p.Category).Distinct();
            foreach (var uniqueCategory in uinque)
            {
                Console.WriteLine(uniqueCategory);
            }
        }

        //26
        //Get a list of unique values from NumbersA and NumbersB.  .Union returns w/ no duplicates
        public static void UniqueAUniqueB()
        {
            int[] array = DataLoader.NumbersA;
            int[] arrayB = DataLoader.NumbersB;
            var unique = array.Union(arrayB);
            foreach (var n in unique)
            {
                Console.WriteLine(n);
            }
        }

        //27
        //Get a list of the shared values from NumbersA and NumbersB. .Intersect return only dulicates
        public static void SharedAB()
        {
            int[] arrayA = DataLoader.NumbersA;
            int[] arrayB = DataLoader.NumbersB;
            var shared = arrayA.Intersect(arrayB);
            foreach (var s in shared)
            {
                Console.WriteLine(s);
            }
        }

        //28
        //Get a list of values in NumbersA that are not also in NumbersB. .Except returns what is unique to the first
        public static void OnlyInA()
        {
            int[] arrayA = DataLoader.NumbersA;
            int[] arrayB = DataLoader.NumbersB;
            var onlyA = arrayA.Except(arrayB);
            foreach (var v in onlyA)
            {
                Console.WriteLine(v);
            }
        }

        // 29
        //Select only the first product with ProductID = 12 (not a list).
        public static void Product12()
        {
            var product = DataLoader.LoadProducts();
            var productID12 = product.First(p => p.ProductID == 12);
            Console.WriteLine(productID12.ProductName);
        }

        //30
        //Write code to check if ProductID 789 exists.
        public static void Product789()
        {
            var product = DataLoader.LoadProducts();
            var product789 = product.FirstOrDefault(p => p.ProductID == 789);
            Console.WriteLine("Product 789 exists: {0}", product789 != null);
        }

        //31
        //Get a list of categories that have at least one product out of stock.
        public static void ProductOutOfStock()
        {
            var product = DataLoader.LoadProducts();
            var outOfStock = from p in product
                group p by p.Category
                into g
                where g.Any(p => p.UnitsInStock == 0)
                select new {Category = g.Key, Products = g};
            foreach (var groupCategory in outOfStock)
            {
                Console.WriteLine("Category: {0}", groupCategory.Category);
            }
        }

        //32
        //Determine if NumbersB contains only numbers less than 9.
        public static void LessThan9()
        {
            int[] array = DataLoader.NumbersB;
            bool lessThan9 = array.Any(a => a < 9);
            Console.WriteLine(lessThan9);
        }

        //33
        //Get a grouped a list of products only for categories that have all of their products in stock.
        public static void AllInStock()
        {
            var product = DataLoader.LoadProducts();
            var inStock = from p in product
                group p by p.Category
                into g
                where g.All(p => p.UnitsInStock != 0)
                select new {Category = g.Key, Product = g};

            foreach (var v in inStock)
            {
                Console.WriteLine("\n{0}\n", v.Category);
                foreach (var p in v.Product)
                {
                    Console.WriteLine("{0} -- {1}", p.ProductName, p.UnitsInStock);
                }
            }

        }

        //34
        //Count the number of odds in NumbersA.  ** COUNT
        public static void OddsInA()
        {
            int[] array = DataLoader.NumbersA;
            var odds = array.Count(a => a%2 != 0);

            Console.WriteLine(odds);
        }

        //35
        //Display a list of CustomerIDs and only the count of their orders.  **.COUNT()
        public static void CountOrders()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var orderCount = from c in customers
                select new {c.CustomerID, Count = c.Orders.Count()};
            foreach (var v in orderCount)
            {
                Console.WriteLine("ID: {0} ---> {1} orders", v.CustomerID, v.Count);
            }

        }

        //36
        //Display a list of categories and the count of their products.
        public static void CountProducts()
        {
            var products = DataLoader.LoadProducts();
            var productCount = from p in products
                group p by p.Category
                into g

                select new {Category = g.Key, Count = g.Count()};
            foreach (var v in productCount)
            {
                Console.WriteLine("In {0} there are {1} products", v.Category, v.Count);
            }
        }

        //37
        //Display the total units in stock for each category
        public static void InStock()
        {
            var products = DataLoader.LoadProducts();
            var units = from p in products
                group p by p.Category
                into g
                select new {Category = g.Key, Total = g.Sum(a => a.UnitsInStock)};
            foreach (var v in units)
            {
                Console.WriteLine("In {0} there are {1} units in stock.", v.Category, v.Total);
            }
        }

        //38
        //Display the lowest priced product in each category. 
        public static void LowestPriced()
        {
            var products = DataLoader.LoadProducts();
            var lowest = from p in products
                group p by p.Category
                into g
                let minPrice = g.Min(p => p.UnitPrice)
                select new {Category = g.Key, Lowest = g.Where(p => p.UnitPrice == minPrice)};
            foreach (var v in lowest)
            {
                Console.WriteLine("{0}:", v.Category);
                foreach (var product in v.Lowest)
                {
                    Console.WriteLine("{0} --- {1}", product.ProductName, product.UnitPrice);
                }
            }
        }

        //39
        //Display the highest priced product in each category.

        public static void HighestPriced()
        {
            var products = DataLoader.LoadProducts();
            var highest = from p in products
                group p by p.Category
                into g
                let maxPrice = g.Max(p => p.UnitPrice)
                select new {Category = g.Key, Highest = g.Where(p => p.UnitPrice == maxPrice)};

            foreach (var v in highest)
            {
                Console.WriteLine("{0}:", v.Category);
                foreach (var product in v.Highest)
                {
                    Console.WriteLine("{0} --- {1}", product.ProductName, product.UnitPrice);
                }
            }
        }

        //40
        //Show the average price of product for each category.
        public static void AveragePrice()
        {
            var products = DataLoader.LoadProducts();
            var average = from p in products
                group p by p.Category
                into g

                select new {Category = g.Key, Average = g.Average(p => p.UnitPrice)};

            foreach (var v in average)
            {
                Console.WriteLine("{0}:", v.Category);
                Console.Write(v.Average);
                //foreach (var averages in v.Average)
                //{
                //    Console.WriteLine("{0}", averages);
                //}

            }
        }
 

    }
}
