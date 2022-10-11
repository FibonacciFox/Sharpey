// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Apf.Controls;
using Apf.Controls.Primitives;
using Avalonia.Controls;
using Avalonia.Layout;
using Pchp.Core;
using Pchp.Core.Reflection;
using Sharpey;
using Sharpey.Primitives;
using Sharpey.Primitives.Property;


//Assembly assembly = Assembly.Load("Avalonia.Controls");
//Type myType = assembly.GetType("Avalonia.Controls.Window");


Type myType = typeof(UxButton);


PhpClass classNamePhpClass = new PhpClass();
classNamePhpClass.Name = myType.Name;
classNamePhpClass.BaseType = myType.BaseType!.ToString();
classNamePhpClass.Namespace = myType.Namespace;

Console.WriteLine($"Является ли тип классом: {myType.IsClass}");
Console.WriteLine($"Имя Класса: {myType.Name}"); 
Console.WriteLine($"Наследуется от: {myType.BaseType}");
Console.WriteLine($"Полное имя типа: {myType.FullName}");
Console.WriteLine($"Пространство имен типа: {myType.Namespace}");
Console.WriteLine("--------------------------------------");


foreach (PropertyInfo prop in myType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static))
{
    if (prop.MemberType == MemberTypes.Property)
    {
        var type = prop.PropertyType.ToString();
        var property = new Property(prop.Name, PropertyType.GetPhpType(type)!, prop.IsPhpPublic(), prop.DeclaringType!.ToString(), prop.CanRead, prop.CanWrite );
        classNamePhpClass.AddProperty(property);
        //Console.WriteLine($"{prop.DeclaringType} {prop.IsPhpPublic()} Тип: {PropertyType.GetPhpType(type)} ${prop.Name} CanRead:{prop.CanRead} CanWrite:{prop.CanWrite}");
      
    }
}

PhpClassBuilder builder = new PhpClassBuilder(classNamePhpClass);
builder.PhpClassBuild();





