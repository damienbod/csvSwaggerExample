using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsvWebApiSwagger
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// https://stackoverflow.com/questions/36452468/swagger-ui-web-api-documentation-present-enums-as-strings
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                model.Enum.Clear();
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(name => model.Enum.Add(new OpenApiString($"{name}")));
            }
        }

        /// <summary>
        /// Apply int enum
        /// </summary>
        /// <param name="model"></param>
        /// <param name="context"></param>
        //public void Apply(OpenApiSchema model, SchemaFilterContext context)
        //{
        //    if (context.Type.IsEnum)
        //    {
        //        model.Enum.Clear();
        //        Enum.GetNames(context.Type)
        //            .ToList()
        //            .ForEach(name => model.Enum.Add(new OpenApiString($"{Convert.ToInt64(Enum.Parse(context.Type, name))} - {name}")));
        //    }
        //}
    }
}
