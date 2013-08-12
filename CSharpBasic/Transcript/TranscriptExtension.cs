using System.Collections.Generic;
using System.Reflection;

namespace CSharpBasic.Transcript
{
    public static class TranscriptExtension
    {
        public static string Print(this Transcript transcript)
        {
            return PrintObject(transcript);
        }
        
        public static string Print(this Grade grade)
        {
            return PrintObject(grade);
        }

        private static string PrintObject<T>(T t)
        {
            var type = typeof (T);
            var properties = new List<string>();
            foreach (var propertyInfo in type.GetProperties())
            {
                var propertyValue = propertyInfo.GetValue(t, null);
                var propertyName = propertyInfo.Name;
                if(null != propertyValue && ExistsDisplayAttribute(propertyInfo))
                {
                      properties.Add(string.Format("{0}: {1}", propertyName, propertyValue));
                }
            }
            return string.Join(", ", properties);
        }

        private static bool ExistsDisplayAttribute(PropertyInfo propertyInfo)
        {
            var customAttributes = propertyInfo.GetCustomAttributes(false);
            foreach (var customAttribute in customAttributes)
            {
                if(customAttribute is DisplayAttribute)
                {
                    return true;
                }
            }
            return false;
        }
    }
}