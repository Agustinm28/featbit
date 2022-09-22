namespace Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator
    {
        get { return _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>(); }
    }

    protected static ApiResponse<TData> Ok<TData>(TData data) => ApiResponse<TData>.Ok(data);

    protected static ApiResponse<TData> Error<TData>(string errorCode) => ApiResponse<TData>.Error(errorCode);
}