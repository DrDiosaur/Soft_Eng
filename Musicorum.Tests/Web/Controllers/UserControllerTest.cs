using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Musicorum.Services.Models;
using Musicorum.Tests.Mocks;
using Musicorum.Web.Controllers;
using System.Linq;
using Xunit;

namespace Musicorum.Tests.Web.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void ControllerShouldBeOnlyForAuhtorizedUsers()
        {
            var controller = typeof(UsersController);

            var attributes = controller.GetCustomAttributes(true);

            attributes
           .Should()
           .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public void IndexShouldReturnViewWhenModelsOK()
        {
            var userService = MockCreator.UserServiceMock();

            var controller = new UsersController(userService.Object);

            var result = controller.AccountDetails(null);

            result
                .Should()
                .BeOfType<ViewResult>();
        }

        [Fact]
        public void IndexShouldReturnNotFoundwhenModelIsNull()
        {
            var userService = MockCreator.UserServiceMock();
            var controller = new UsersController(userService.Object);

            var result = controller.AccountDetails(null);

            result
                .Should()
                .BeOfType<NotFoundResult>();
        }
    }
}