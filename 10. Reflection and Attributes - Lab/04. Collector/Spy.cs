using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string CollectGettersAndSetters(string className)
        {
            Type investigatedClassType = Type.GetType(className);

            MethodInfo[] methods = investigatedClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("get")))
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");

            foreach (MethodInfo method in methods.Where(m => m.Name.StartsWith("set")))
                stringBuilder.AppendLine($"{method.Name} will set {method.GetParameters().First().ParameterType}");

            return stringBuilder.ToString().Trim();
        }
    }
}
