using System;

namespace CSharpBasic.Transcript
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false), Serializable]
    public class DisplayAttribute : Attribute
    {
    }
}