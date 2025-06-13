using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace RazorPagesLabA1.Binding
{
    public class CheckNameBinding : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var valueResult = context.ValueProvider.GetValue(context.ModelName);
            if (valueResult == ValueProviderResult.None) return Task.CompletedTask;

            var value = valueResult.FirstValue?.ToUpper();
            if (string.IsNullOrEmpty(value)) return Task.CompletedTask;

            if (value.Contains("XXX"))
            {
                context.ModelState.TryAddModelError(context.ModelName, "Cannot contain XXX");
                return Task.CompletedTask;
            }

            context.Result = ModelBindingResult.Success(value.Trim());
            return Task.CompletedTask;
        }
    }
}
