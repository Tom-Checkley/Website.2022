using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace TomCheckley.Core.Factories.Concrete
{
    public class UmbracoContentToModelFactory<T>
    {
        private readonly string _namespace;
        private readonly string _appendToDocTypeAlias;
        private readonly Type _fallbackType;

        protected UmbracoContentToModelFactory(string modelNamespace, string appendToDocTypeAlias = "", Type fallbackType = null)
        {
            _namespace = modelNamespace.EnsureEndsWith(".");
            _appendToDocTypeAlias = appendToDocTypeAlias;
            _fallbackType = fallbackType;
        }

        public virtual T Create(IPublishedElement content, params object[] args)
        {
            var docTypeAlias = content.ContentType.Alias.First().ToString().ToUpper() + content.ContentType.Alias.Substring(1);
            var type = Type.GetType(_namespace + docTypeAlias + _appendToDocTypeAlias) ?? _fallbackType;

            if (type == null)
            {
                throw new NotImplementedException(
                    string.Format("Class: {0} couldn't be found for Content Type Alias: '{1}'.{2}Create the model in the namespace: {3}",
                        docTypeAlias,
                        content.ContentType.Alias,
                        Environment.NewLine,
                        _namespace
                ));
            }

            List<object> argsList = new() { content };

            if (args != null)
            {
                argsList.AddRange(args);
            }

            object model = Activator.CreateInstance(type, argsList.ToArray());
            return (T)model;
        }
    }
}