using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    [EnableCors("FrontPolicy")]
    public class CustomBaseController : ControllerBase
    {
    }
}