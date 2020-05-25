using System;

namespace ContactsWebApp.Framework.Attributes
{
    public class HtmlIdAttribute : Attribute
    {
        public string Id { get; }
        public string IdSSO { get; }

        public HtmlIdAttribute(string id, string idSso = null)
        {
            Id = id;
            IdSSO = idSso ?? id;
        }
    }
}
