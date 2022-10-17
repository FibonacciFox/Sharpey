using System.Reflection;
using Pchp.Core.Reflection;
using Sharpey.Primitives.Event;
using Sharpey.Primitives.Field;
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
    
    public List<PhpField> Fields
    {
        get => _fields;
    }
    
    public List<PhpEvent> Events
    {
        get => _events;
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
    
    public void AddField(PhpField field)
    {
        _fields.Add(field);
    }
    
    public void RemoveField(int indexField)
    {
        _fields.RemoveAt(indexField);
    }
    
    public void AddEvent(PhpEvent eventPhp)
    {
        _events.Add(eventPhp);
    }
    
    public void RemoveEvent(int indexEvent)
    {
        _events.RemoveAt(indexEvent);
    }
    
    
    private string _name;
    private string _phpFullName = null!;
    private string _baseType;
    private string? _namespacePhp;
    private Type _sharpObjectType;
    
    private readonly List<PhpProperty> _properties = new();
    private readonly List<PhpField> _fields = new();
    private readonly List<PhpEvent> _events = new();


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
        foreach (PropertyInfo prop in _sharpObjectType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static))
        {
            //if (prop.MemberType == MemberTypes.Property)
           // {
                var type = prop.PropertyType.ToString();
                var property = new PhpProperty(prop.Name, PropertyType.GetPhpType(type)!, prop.IsPhpPublic(), prop.DeclaringType!.ToString(), prop.CanRead, prop.CanWrite );
                AddProperty(property);
               
                // }
        }
        SetPublicFieldSync();
        SetPublicEventSync();
    }
    
    public void SetPublicFieldSync()
    {
        foreach (FieldInfo prop in _sharpObjectType.GetFields(BindingFlags.Instance | BindingFlags.Public))
        {
            var type = prop.FieldType.ToString();
            
            var property = new PhpField(prop.Name, PropertyType.GetPhpType(type)!, true, prop.DeclaringType!.ToString());
            AddField(property);
        }
        
        Console.WriteLine("Поля:");
        foreach (FieldInfo field in _sharpObjectType.GetFields(
                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static))
        {
            string modificator = "";
 
            // получаем модификатор доступа
            if (field.IsPublic)
                modificator += "public ";
            else if (field.IsPrivate)
                modificator += "private ";
            else if (field.IsAssembly)
                modificator += "internal ";
            else if (field.IsFamily)
                modificator += "protected ";
            else if (field.IsFamilyAndAssembly)
                modificator += "private protected ";
            else if (field.IsFamilyOrAssembly)
                modificator += "protected internal ";
 
            // если поле статическое
            if (field.IsStatic) modificator += "static ";
 
            Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
        } 
    }

    public void SetPublicEventSync()
    {
        foreach (EventInfo prop in _sharpObjectType.GetEvents(BindingFlags.Instance | BindingFlags.Public))
        {
            var type = prop.MemberType.ToString();
            
            var property = new PhpEvent(prop.Name, PropertyType.GetPhpType(type)!, true, prop.DeclaringType!.ToString());
            AddEvent(property);
            
        }
    }
}