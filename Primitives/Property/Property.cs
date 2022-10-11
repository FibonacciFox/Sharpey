namespace Sharpey.Primitives.Property;



public struct Property
{
    public string Name;
    public string Type;
    
    public bool IsPublic;
    
    public string DeclaringType;
    
    public bool CanRead;
    public bool CanWrite;

    public string[]? PhpDock;

    public Property(string name, string type, bool isPublic , string declaringType, bool canRead, bool canWrite, string[]? phpDock  = null)
    {
        Name = name;
        Type = type;
        DeclaringType = declaringType;
        CanRead = canRead;
        CanWrite = canWrite;
        PhpDock = phpDock;
        IsPublic = isPublic;
    }
}