using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTests
{
    public class TextConfigurationSource : IConfigurationSource
    {
        public string FileName { get; set; }

        public TextConfigurationSource(string fielName)
        {
            FileName = fielName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string filePath = builder.GetFileProvider().GetFileInfo(FileName).PhysicalPath;
            return new TextConfigurationProvider(filePath);
        }
    }
}
