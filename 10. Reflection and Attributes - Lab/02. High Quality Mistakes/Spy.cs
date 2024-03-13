using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type investigatedType = Type.GetType(className);

            FieldInfo[] fields = investigatedType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = investigatedType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = investigatedType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in fields)
                stringBuilder.AppendLine($"{field.Name} must be private!");

            foreach (MethodInfo method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
                stringBuilder.AppendLine($"{method.Name} have to be public!");

            foreach (MethodInfo method in publicMethods.Where(m => m.Name.StartsWith("set")))
                stringBuilder.AppendLine($"{method.Name} have to be private!");

            return stringBuilder.ToString().Trim();
        }
    }
}
