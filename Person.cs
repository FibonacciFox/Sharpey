namespace Sharpey;

public class Person
{

    public static readonly string Gorod = "GOROD";
    private string _name;

    public const string GOROD = "GOROD";
    
    public int Age { get; }
    public string Sex { get; set; }

    public string Name
    {
        set => _name = value;
    }
    public Person(string name, int age)
    {
       _name = name;
        Age = age;
    }
    
    public void Print(int s) => Console.WriteLine($"Name: {_name} Age: {Age}");
}