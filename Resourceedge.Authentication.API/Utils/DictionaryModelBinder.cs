using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;


namespace Resourceedge.Authentication.API.Utils
{
    public class DictionaryModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Our binder only works on enumerable types
            if (!bindingContext.ModelMetadata.IsEnumerableType)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }

           var Body =  bindingContext.HttpContext.Items["request_body"].ToString();
            if (Body == null)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
            }



            //Get the inputted value through the value provider
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).ToString();

            var deserializedBody = JsonSerializer.Deserialize<Dictionary<string, IEnumerable<Claim>>>(Body);

            bindingContext.Result = ModelBindingResult.Success(deserializedBody);

            ////if that value is null or whitespace, we return null
            //if (string.IsNullOrWhiteSpace(value))
            //{
            //    bindingContext.Result = ModelBindingResult.Success(null);
            //    return Task.CompletedTask;
            //}

            ////The value isn't null or whitespace,
            //// and the type of the model is enumerable
            ////Get the enumerable's type, and a converter
            //var elementType = bindingContext.ModelType.GetTypeInfo().GenericTypeArguments[0];
            //var converter = TypeDescriptor.GetConverter(elementType);

            ////Converts each item in the value list to  the enumerable type
            //var values = value.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(x => converter.ConvertFromString(x.Trim())).ToArray();

            ////Create an array of that type and set it as the model
            //var typedValues = Array.CreateInstance(elementType, values.Length);
            //values.CopyTo(typedValues, 0);
            //bindingContext.Model = typedValues;

            ////return a successful result, passing in the model
            //bindingContext.Result = ModelBindingResult.Success(bindingContext.Model);
            return Task.CompletedTask;
        }
    }
}
