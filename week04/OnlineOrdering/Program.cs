using System;

class Program
{
    private static List<Order> _orderList = new List<Order>();
    static void Main(string[] args)
    {
        PopulateOrders();
        foreach (Order order in _orderList)
        {
            Console.WriteLine(order.GetDisplayString());
        }
    }
    static void PopulateOrders()
    {
        Order order1 = new Order(new Customer("Alice Handy", new Address("1947 S Columbia Ln Apt 19", "Orem", "UT", "USA")));
        order1.AddProduct(new Product("Yarn (Pink)", 6190481, 9, 3));
        order1.AddProduct(new Product("Button, set of 20 (Black)", 9930249, 5, 8));
        order1.AddProduct(new Product("Crochet Hook Set", 7005370, 24, 1));
        _orderList.Add(order1);

        Order order2 = new Order(new Customer("Bishop Britez", new Address("Nuestra Señora de la Asunción 1117", "Villa Elisa", "Central", "Paraguay")));
        order2.AddProduct(new Product("Come Follow Me 2025 Manual - Spanish", 8120004, 4, 47));
        order2.AddProduct(new Product("Youth Crystal - Emblem of Achievement", 4613433, 7, 4));
        order2.AddProduct(new Product("Oil Vial for Young Men - Emblem of Belonging", 9054819, 8, 8));
        _orderList.Add(order2);

        Order order3 = new Order(new Customer("Angel Moroni", new Address("Hill Cumorah", "Manchester", "NY", "USA")));
        order3.AddProduct(new Product("Brass Plate Set (2025 Edition)", 4137119, 50, 3));
        order3.AddProduct(new Product("Urim and Thummim", 2050578, 275, 1));
        order3.AddProduct(new Product("Seer Stones", 2706460, 20, 14));
        _orderList.Add(order3);
    }
}