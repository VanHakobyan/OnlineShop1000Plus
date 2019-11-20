using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
    }
}