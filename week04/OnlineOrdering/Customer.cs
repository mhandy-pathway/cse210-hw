public class Customer
{
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Public Interface Methods
    public bool IsFromUSA()
    {
        // Call from Address
        return _address.IsFromUSA();
    }
    public string GetDisplayString()
    {
        return $"{_name}\n{_address.GetAddressString()}";
    }
}