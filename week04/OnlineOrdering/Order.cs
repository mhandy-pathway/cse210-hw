public class Order
{
    private Customer _customer;
    private List<Product> _productList = new List<Product>();

    // Constructors
    public Order(Customer customer)
    {
        _customer = customer;
    }

    // Public Interface Methods
    public void AddProduct(Product product)
    {
        _productList.Add(product);
    }
    public int CalculateTotal()
    {
        int total = 0;
        foreach (Product product in _productList)
        {
            total += product.CalculateTotal();
        }
        total += CalculateOneTimeShippingCost();
        return total;
    }
    public string GetPackingLabelString()
    {
        // List the name and product id of each product in the order
        string returnStr = "";
        foreach (Product product in _productList)
        {
            returnStr += $"{product.GetDisplayString()}\n";
        }
        return returnStr;
    }
    public string GetShippingLabelString()
    {
        // List the name and address of the customer
        return $"{_customer.GetDisplayString()}\n";
    }
    public string GetDisplayString()
    {
        string returnStr = "ORDER DETAILS:\n";
        returnStr += "-----------------------------\n";
        returnStr += $"Packing Label:\n{GetPackingLabelString()}\n";
        returnStr += $"Shipping Label:\n{GetShippingLabelString()}\n";
        returnStr += $"Shipping Cost: ${CalculateOneTimeShippingCost()}\n";
        returnStr += $"Order Total: ${CalculateTotal()}\n";
        returnStr += "-----------------------------\n\n";
        return returnStr;
    }

    // Private Helper Methdos
    private int CalculateOneTimeShippingCost()
    {
        if (_customer.IsFromUSA())
        {
            return 5;
        }
        else
        {
            return 35;
        }
    }
}