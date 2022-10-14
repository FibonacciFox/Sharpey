// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Apf.Controls;
using Pchp.Core.Reflection;
using Sharpey;
using Sharpey.Avascript;
using Sharpey.Primitives;
using Sharpey.Primitives.Property;


//Assembly assembly = Assembly.Load("Apf");
//Type? myType = assembly.GetType("Apf.Controls.UxButton");




Type SharpObject = typeof(Person);



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


foreach (MemberInfo member in SharpObject.GetMembers(BindingFlags.DeclaredOnly
                                                     | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
{
    Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
}






