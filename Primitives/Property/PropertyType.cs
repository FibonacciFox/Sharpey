namespace Sharpey.Primitives.Property;

public static class PropertyType
{
  public const string Boolean = "System.Boolean";
  public const string Object = "System.Object";
  public const string Double = "System.Double";
  public const string Int32 = "System.Int32";
  public const string String = "System.String";
  public const string Int64 = "System.Int64";
  public const string Int16 = "System.Int16";
  
  public static string? GetPhpType(string sharpPropertyType)
  {
    switch (sharpPropertyType)
    {
      case Boolean: return "bool";
      case Object: return "object";
      case Double: return "float";
      case String: return "string";
      case Int32: return "int";
      case Int64: return "int";
      case Int16: return "int";

      default:
      {
        return GetClassPropertyType(sharpPropertyType);
      } // временная заглушка на остальные типы}
    }
  }

  public static string? GetClassPropertyType(string sharpPropertyType)
  {
    
      string[] sharpArrayPropertyType = sharpPropertyType.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);

      if (sharpArrayPropertyType[^1].IndexOf("]", StringComparison.Ordinal) == -1) // временная заглушка 
      {
        return sharpArrayPropertyType[sharpArrayPropertyType.Length - 1];
      }

      return "mixed";
  }
}

