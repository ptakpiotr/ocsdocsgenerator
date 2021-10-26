using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DocGenerator.Attributes;
using DocGenerator.Models;

namespace DocGenerator.DocumentationCreator
{
    public class Creator
    {
        public List<DocumentationModel> docs { get; set; } = new List<DocumentationModel>();

        public Creator(Type type, string namespaceFragment)
        {
            Assembly mscorlib = type.Assembly;

            var types = mscorlib.GetTypes()
                .Where(t => t.ToString().StartsWith(namespaceFragment)).ToArray();

            for (int i = 0; i < types.Length; i++)
            {
                Create(types[i]);
            }

            JsonSaver.SaveToJson(docs);
        }

        public void Create(Type T)
        {
            Type scType = T;

            var documentedMethods = scType.GetMethods().Where(m => m.DeclaringType != typeof(object));

            foreach (var method in documentedMethods)
            {
                var attrs = method.GetCustomAttributesData().Where(at => at.AttributeType == typeof(DocumentationAttribute));

                if (attrs.Any())
                {
                    List<string> docuInfo = new List<string>();

                    foreach (var a in attrs)
                    {
                        docuInfo.Add(a.ConstructorArguments.First().Value.ToString());
                    }

                    docs.Add(DocsGenerator.GenerateDocs(method, docuInfo));
                }
            }
        }
    }
}
