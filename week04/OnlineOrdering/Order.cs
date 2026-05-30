public class Order
{
    private List<Product> _products;
    private Customer _customer;

    private const double _domesticShipping = 5.0;
    private const double _internationalShipping = 35.0;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        total += _customer.LivesInUSA() ? _domesticShipping : _internationalShipping;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "--- Packing Label ---\n";
        foreach (Product product in _products)
        {
            label += $"  Product: {product.GetName()}  |  ID: {product.GetProductId()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"--- Shipping Label ---\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
