using System;

namespace ContactsWebApp.Framework.Attributes
{
    public class LinkTextAttribute : Attribute
    {
        public string LinkText { get; }

        public LinkTextAttribute(string linkText)
        {
            LinkText = linkText;
        }
    }
}
