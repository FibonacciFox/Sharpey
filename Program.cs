// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Apf.Controls;


//Assembly assembly = Assembly.Load("Avalonia.Controls");
//Type myType = assembly.GetType("Avalonia.Controls.Window");

Type myType = typeof(UxButton);




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
        Console.WriteLine($"[Унаследовано от:{prop.DeclaringType}] [Значение типа:{prop.MemberType}] Тип: {prop.PropertyType} [Имя свойства:{prop.Name}]");
    }
    
}



