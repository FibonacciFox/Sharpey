// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Apf.Controls;
using Avalonia.Controls;

//Assembly assembly = Assembly.Load("Avalonia.Controls");
//Type myType = assembly.GetType("Avalonia.Controls.Window");
Type myType = typeof(UxWindow);


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
        Console.WriteLine($"{prop.DeclaringType} {prop.MemberType} {prop.PropertyType} {prop.Name}");
    }
    
}

namespace Apf.Controls
{
    class UxWindow : Window
    {

    }
}