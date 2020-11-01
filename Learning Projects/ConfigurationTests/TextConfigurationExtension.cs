using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTests
{
    public static class TextConfigurationExtension
    {
        public static IConfigurationBuilder AddTextFile(this IConfigurationBuilder builder, string path)
        {
            if (builder == null || string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Incorect params values");
            }

            var source = new TextConfigurationSource(path);
            builder.Add(source);
            return builder;
        }
    }
}
