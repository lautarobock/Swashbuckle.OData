using System;
using System.Diagnostics.Contracts;
using System.Web.OData;
using Swashbuckle.Swagger;

namespace Swashbuckle.OData
{
    internal static class SchemaExtensions
    {
        public static Type GetReferencedType(this Schema schema)
        {
            Contract.Requires(schema != null);

            if (schema.@ref != null)
            {
                var fullTypeName = schema.@ref.Replace("#/definitions/", string.Empty);

                try
                {
                    return TypeHelper.FindType(fullTypeName);
                }
                catch (Exception)
                {

                    return null;
                }
            }

            return null;
        }
    }
}