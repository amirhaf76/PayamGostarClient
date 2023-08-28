﻿using NJsonSchema;

namespace PayamGosterApiGenerator.NameGenerators
{
    public class LegacyTypeNameGenerator : ITypeNameGenerator
    {
        private readonly DefaultTypeNameGenerator _defaultTypeNameGenerator;

        public LegacyTypeNameGenerator()
        {
            _defaultTypeNameGenerator = new DefaultTypeNameGenerator();
        }

        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames)
        {
            return _defaultTypeNameGenerator.Generate(schema, $"Legacy{typeNameHint}", reservedTypeNames);
        }
    }
}