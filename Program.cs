// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Avalonia.Controls;
using Pchp.Core.Reflection;
using Sharpey;
using Sharpey.Primitives;


//Assembly assembly = Assembly.Load("Avalonia.Controls");
//Type myType = assembly.GetType("Avalonia.Controls.Window");

Type myType = typeof(Button);

Console.WriteLine($"Является ли тип классом: {myType.IsClass}");
Console.WriteLine($"Имя Класса: {myType.Name}"); 
Console.WriteLine($"Наследуется от: {myType.BaseType}");
Console.WriteLine($"Полное имя типа: {myType.FullName}");
Console.WriteLine($"Пространство имен типа: {myType.Namespace}");
Console.WriteLine("--------------------------------------"); 

foreach (PropertyInfo prop in myType.GetProperties(BindingFlags.Instance | BindingFlags.Public))
{
    if (prop.MemberType == MemberTypes.Property)
    {
        var type = prop.PropertyType.ToString();
       
        Console.WriteLine($"{prop.DeclaringType} {prop.IsPhpPublic()} Тип: {PropertyType.GetPhpType(type)} ${prop.Name} CanRead:{prop.CanRead} CanWrite:{prop.CanWrite}");
    }
    
}



