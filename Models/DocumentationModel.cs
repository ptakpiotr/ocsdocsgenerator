using System;
using System.Collections.Generic;

namespace DocGenerator.Models
{
    public class DocumentationModel
    {
        public Guid Id { get; set; }
        public string FullMethodName { get; set; }
        public string MethodParams { get; set; }
        public List<string> DocumentationAttributes { get; set; }
    }
}
