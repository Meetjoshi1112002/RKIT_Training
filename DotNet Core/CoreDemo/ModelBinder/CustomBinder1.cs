using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CoreDemo.ModelBinder
{
    public class CustomBinder1 : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var result = data.TryGetValue("countries", out var output);

            if(result)
            {
                string[] arr = output.ToString().Split(',');

                bindingContext.Result = ModelBindingResult.Success(arr);
            }

            return Task.CompletedTask;
        }
    }
}
