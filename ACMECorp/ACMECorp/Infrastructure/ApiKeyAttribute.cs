using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

public class ApiKeyAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var apiKeyHeader = "ACMECorp-123";
        var config = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var apiKey = config.GetValue<string>("ApiKey");

        if (!context.HttpContext.Request.Headers.TryGetValue(apiKeyHeader, out StringValues providedApiKey)
            || !apiKey.Equals(providedApiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        base.OnActionExecuting(context);
    }
}
