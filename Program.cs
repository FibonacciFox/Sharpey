// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Apf.Controls;
using Avalonia.Controls;
using Pchp.Core.Reflection;
using Sharpey;
using Sharpey.Primitives;
using Sharpey.Primitives.Property;


//Assembly assembly = Assembly.Load("Apf");
//Type? myType = assembly.GetType("Apf.Controls.UxButton");



Type SharpObject = typeof(UxWindow);



if (SharpObject.IsClass)
{
    Console.WriteLine("Объект имеет тип Class!");
    
    PhpClass phpClass = new (SharpObject);
    
    Console.WriteLine($"Имя Класса: {phpClass.Name}"); 
    Console.WriteLine($"Наследуется от: {phpClass.BaseType}");
    Console.WriteLine($"Полное имя PHP типа: {phpClass.FullName}");
    Console.WriteLine($"PHP пространство имен типа: {phpClass.Namespace}");
    Console.WriteLine("--------------------------------------");

    phpClass.SetPublicPropertiesSync();
    
    PhpClassBuilder builder = new PhpClassBuilder(phpClass);
    builder.PhpClassBuild();
    
}







