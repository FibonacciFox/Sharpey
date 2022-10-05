// See https://aka.ms/new-console-template for more information

using System.Reflection;



Assembly assembly = Assembly.Load("Avalonia.Controls");

//Type myType = typeof(TemplatedControl);

Type myType = assembly.GetType("Avalonia.Controls.Window");


Console.WriteLine($"Is class: {myType.IsClass}");       // является ли тип классом
Console.WriteLine($"Имя Класса: {myType.Name}");              // получаем краткое имя типа
Console.WriteLine($"Наследуется от: {myType.BaseType}");
Console.WriteLine($"Full Name: {myType.FullName}");     // получаем полное имя типа
Console.WriteLine($"Namespace: {myType.Namespace}");    // получаем пространство имен типа
Console.WriteLine($"Is struct: {myType.IsValueType}");  // является ли тип структурой
Console.WriteLine("--------------------------------------"); 

foreach (MemberInfo member in myType.GetMembers( BindingFlags.Instance | BindingFlags.Public))
{
    if (member.MemberType == MemberTypes.Property)
    {
        //var ageProp = myType.GetProperty(member.Name);
        Console.WriteLine($"Унаследовано от: {member.DeclaringType} Значение типа: {member.MemberType} Имя свойства: {member.Name}");
    }
}



