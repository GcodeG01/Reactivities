using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/CLASSNAME, [controller] removes the word "controller" from class name
    public class BaseApiController : ControllerBase
    {
        
    }
}