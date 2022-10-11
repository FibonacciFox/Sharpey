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
        properyClass.Add($"public class {_phpClass.Name} " + "{");
        
        foreach (Property property in _phpClass.Properties)
        {
            properyClass.Add("");
            properyClass.Add("/**");
            properyClass.Add(" *");
            properyClass.Add(" *");
            properyClass.Add($" * @var {property.Type} ${property.Name} ");
            properyClass.Add(" */");
            properyClass.Add($" public {property.Type} ${property.Name};");
        }
        
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