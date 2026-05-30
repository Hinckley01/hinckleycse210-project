class Program
{
    static void Main(string[] args)
    {
        // --- Order 1: Domestic (USA) customer ---
        Address address1 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Homer Simpson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1042", 29.99, 2));
        order1.AddProduct(new Product("USB Hub", "UH-308", 15.49, 1));
        order1.AddProduct(new Product("HDMI Cable", "HC-205", 9.99, 3));

        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nOrder Total: ${order1.GetTotalCost():F2}");
        Console.WriteLine("(Includes $5.00 domestic shipping)");

        Console.WriteLine();

        // --- Order 2: International customer ---
        Address address2 = new Address("221B Baker Street", "London", "England", "UK");
        Customer customer2 = new Customer("Sherlock Holmes", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-777", 89.95, 1));
        order2.AddProduct(new Product("Monitor Stand", "MS-410", 34.50, 2));

        Console.WriteLine("========== ORDER 2 ==========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nOrder Total: ${order2.GetTotalCost():F2}");
        Console.WriteLine("(Includes $35.00 international shipping)");
    }
}
