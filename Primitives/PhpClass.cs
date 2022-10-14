using System.Reflection;
using Pchp.Core.Reflection;
using Sharpey.Primitives.Property;

namespace Sharpey.Primitives;

public class PhpClass
{
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string FullName
    {
        get => _phpFullName;
        set
        {
            _phpFullName = GetPhpNamespace(value);
        }
    }

    public string BaseType
    {
        get => _baseType;
        set => _baseType = value;
    }
    
    public string? Namespace
    {
        get => _namespacePhp;
        set
        {
            _namespacePhp = GetPhpNamespace(value!);
        }
    }

    public List<PhpProperty> Properties
    {
        get => _properties;
    }

    public string Constructor
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }

    public void AddProperty(PhpProperty property)
    {
        _properties.Add(property);
    }
    
    public void RemoveProperty(int indexProperty)
    {
        _properties.RemoveAt(indexProperty);
    }
    
    
    private string _name;
    private string _phpFullName = null!;
    private string _baseType;
    private string? _namespacePhp;
    private Type _sharpObjectType;
    
    private readonly List<PhpProperty> _properties = new();
    

    public PhpClass(Type sharpObjectType)
    {
        _name = sharpObjectType.Name;
        _baseType = sharpObjectType.BaseType!.ToString();
        Namespace = sharpObjectType.Namespace;
        FullName = sharpObjectType.FullName ?? string.Empty;
        _sharpObjectType = sharpObjectType;
        
    }

    private string GetPhpNamespace(string sharpNamespace )
    {
       return  sharpNamespace.Replace(".", "\\");
    }

    /// <summary>
    /// Находим публичные поля шарп класс и задаем свойства php класса на их основе.
    /// </summary>
    public void SetPublicPropertiesSync()
    {
        foreach (PropertyInfo prop in _sharpObjectType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
        {
            //if (prop.MemberType == MemberTypes.Property)
           // {
                var type = prop.PropertyType.ToString();
                var property = new PhpProperty(prop.Name, PropertyType.GetPhpType(type)!, prop.IsPhpPublic(), prop.DeclaringType!.ToString(), prop.CanRead, prop.CanWrite );
                AddProperty(property);
               
                // }
        }
        SetPublicFieldSync();
    }
    
    public void SetPublicFieldSync()
    {
        foreach (FieldInfo prop in _sharpObjectType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static))
        {
            var type = prop.FieldType.ToString();
            
            var property = new PhpProperty(prop.Name, PropertyType.GetPhpType(type)!, prop.IsPhpPublic(), prop.DeclaringType!.ToString(), true, true );
            AddProperty(property);
            
        }
    }
}