using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musicorum.Services;
using Musicorum.Services.Models;
using Musicorum.Web.Extensions;
using Musicorum.Web.Infrastructure;

namespace Musicorum.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [Authorize]
        public IActionResult AccountDetails(string id)
        {
            if (User.GetUserId() == id)
            {
                ViewData[GlobalConstants.Authorization] = GlobalConstants.FullAuthorization;
            }
            else
            {
                ViewData[GlobalConstants.Authorization] = GlobalConstants.NoAuthorization;
            }

            UserAccountModel user = this.userService.UserDetails(id);

            return this.ViewOrNotFound(user);
        }
    }
}