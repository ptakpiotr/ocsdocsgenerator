using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DocGenerator.Models;

namespace DocGenerator.DocumentationCreator
{
    public static class DocsGenerator
    {

        public static DocumentationModel GenerateDocs(MethodInfo method, List<string> docuInfo)
        {
            DocumentationModel md = new DocumentationModel()
            {
                Id = Guid.NewGuid(),
                FullMethodName = $"{method.DeclaringType}.{method.Name} [{method.ReturnType.ToString()}]",
                DocumentationAttributes = docuInfo,
                MethodParams = $"{String.Join(",", method.GetParameters().Select(p => $"[{p.ParameterType}] {p.Name}"))}"
            };

            return md;
        }
    }
}
