using School.Api.Entities;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace School.Api.Helpers
{
    public static class EnumExtensions
    {
        public static string MyGetDisplayName(this LessonStatus enumValue)
        {
            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());
            if (memberInfo.Length > 0)
            {
                var displayAttribute = memberInfo[0].GetCustomAttribute<DisplayAttribute>();
                if (displayAttribute != null)
                {
                    return displayAttribute.Name; // Retrieve the Display Name
                }
            }

            return enumValue.ToString(); // Fallback to enum name
        }
    }
}
