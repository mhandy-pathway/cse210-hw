public class Product
{
    private string _name;
    private int _productId;
    private int _price;
    private int _quantity;

    // Constructor
    public Product(string name, int productId, int price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Public Interface Methods
    public int CalculateTotal()
    {
        return _price * _quantity;
    }
    public string GetDisplayString()
    {
        return $"{_quantity} x {_name} (ID: {_productId}) @ ${_price} = ${CalculateTotal()}";
    }
}