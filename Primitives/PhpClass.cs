namespace Sharpey.Primitives;

public class PhpClass
{
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string ClassFullName
    {
        get => _classFullName;
        set => _classFullName = value;
    }

    public string BaseType
    {
        get => _baseType;
        set => _baseType = value;
    }
    
    public string? Namespace
    {
        get => _namespace;
        set
        {
            _namespace = GetPhpNamespace(value!);
        }
    }

    public List<Property.Property> Properties
    {
        get => _properties;
    }
    
    
    public void AddProperty(Property.Property property)
    {
        _properties.Add(property);
    }
    
    public void RemoveProperty(int indexProperty)
    {
        _properties.RemoveAt(indexProperty);
    }
    
    
    
    private string _name;
    private string _classFullName;
    private string _baseType;
    private string? _namespace;
    private readonly List<Property.Property> _properties = new();

    private string GetPhpNamespace(string sharpNamespace )
    {
       return  sharpNamespace.Replace(".", "\\");
    }
}