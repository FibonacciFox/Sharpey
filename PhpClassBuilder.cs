using Sharpey.Primitives;
using Sharpey.Primitives.Property;

namespace Sharpey;

public class PhpClassBuilder
{
    private PhpClass _phpClass;

    public PhpClassBuilder(PhpClass phpClass)
    {
        _phpClass = phpClass;
    }


    public void PhpClassBuild()
    {
        List<string> properyClass = new List<string>();
        properyClass.Add("<?php");
        properyClass.Add("");
        properyClass.Add($"namespace {_phpClass.Namespace};");
        properyClass.Add("");
        
        properyClass.Add("");
        properyClass.Add("/**");
        foreach (PhpProperty property in _phpClass.Properties)
        {
            
            if (property.CanRead && property.CanWrite)
            { 
                properyClass.Add($" * @property {property.Type} ${property.Name} [description] ");
            }
            
            if (property.CanRead && !property.CanWrite)
            { 
                properyClass.Add($" * @property-read {property.Type} ${property.Name} [description] ");
            }
            
            if (!property.CanRead && property.CanWrite)
            { 
                properyClass.Add($" * @property-write {property.Type} ${property.Name} [description] ");
            }
            
        }
        
        properyClass.Add(" */");
        
        properyClass.Add($"class {_phpClass.Name} " + "{");
        properyClass.Add("");
        properyClass.Add("}");
        
        using (StreamWriter writer = new StreamWriter($"./sdk/Apf/Controls/{_phpClass.Name}.php"))
        {
            foreach (string str in properyClass)
            {
                writer.WriteLine(str);
            }
        }
    }
}