using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Tec.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}