using System;

namespace Bonex.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ViewDefinitionAttribute : Attribute
    {
        public ViewDefinitionAttribute(string definition)
        {
            Definition = definition;
        }
        
        public string Definition { get; private set; }
    }
}
