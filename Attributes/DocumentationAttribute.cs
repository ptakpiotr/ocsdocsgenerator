using System;

namespace DocGenerator.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class DocumentationAttribute : Attribute
    {
        public string Description { get; private set; }

        public DocumentationAttribute(string value)
        {
            Description = value;
        }
    }
}
