using System;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;


namespace Tec.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}