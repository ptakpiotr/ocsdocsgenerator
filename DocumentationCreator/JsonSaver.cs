using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DocGenerator.Models;

namespace DocGenerator.DocumentationCreator
{
    public static class JsonSaver
    {
        public static void SaveToJson(List<DocumentationModel> li)
        {
            using (StreamWriter sw = new StreamWriter($"./docs_{Guid.NewGuid().ToString().Replace("-", "_")}.json"))
            {
                sw.WriteLine("{");
                sw.WriteLine($"\"Methods\":{JsonSerializer.Serialize(li)},");
                sw.WriteLine("}");
            }
        }
    }
}
