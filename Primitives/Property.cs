namespace Sharpey.Primitives;



public struct Property
{
    public string Name;
    public string Type;
    public string DeclaringType;
    
    public bool CanRead;
    public bool CanWrite;

    public Property(string name, string type, string declaringType, bool canRead, bool canWrite )
    {
        Name = name;
        Type = type;
        DeclaringType = declaringType;
        CanRead = canRead;
        CanWrite = canWrite;
    }

    
}