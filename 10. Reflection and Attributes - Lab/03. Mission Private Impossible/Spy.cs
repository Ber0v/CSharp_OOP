using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Type investigatedClassType = Type.GetType(className);

            MethodInfo[] privateMethods = investigatedClassType.GetMethods(BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {investigatedClassType.BaseType.Name}");

            foreach (MethodInfo method in privateMethods)
                stringBuilder.AppendLine(method.Name);

            return stringBuilder.ToString().Trim();
        }
    }
}
