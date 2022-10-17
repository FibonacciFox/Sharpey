﻿namespace Sharpey.Primitives.Event;

public class PhpEvent
{
    public string Name;
    public string Type;
    
    public bool IsPublic;
    
    public string DeclaringType;
    
    public string[]? PhpDock;

    public PhpEvent(string name, string type, bool isPublic , string declaringType, string[]? phpDock  = null)
    {
        Name = name;
        Type = type;
        DeclaringType = declaringType;
        PhpDock = phpDock;
        IsPublic = isPublic;
    }
}