namespace Sharpey.Primitives.Property;

public struct PhpProperty
{
    public string Name;
    public string Type;
    
    public bool IsPublic;
    
    public string DeclaringType;
    
    public bool CanRead;
    public bool CanWrite;

    public string[]? PhpDock;

    public PhpProperty(string name, string type, bool isPublic , string declaringType, bool canRead, bool canWrite, string[]? phpDock  = null)
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