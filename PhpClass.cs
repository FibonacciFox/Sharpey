using Sharpey.Primitives;

namespace Sharpey;

public class PhpClass
{
    public string ClassName => _className;
    
    public string ClassFullName => _classFullName;

    public string BaseType => _baseType;

    public List<Property> Properties
    {
        get => _properties;
    }
    
    
    public void AddProperty(Property property)
    {
        _properties.Add(property);
    }
    
    public void RemoveProperty(int indexProperty)
    {
        _properties.RemoveAt(indexProperty);
    }
    
    
    private string _className;
    private string _classFullName;
    private string _baseType;
    private readonly List<Property> _properties = new();
}