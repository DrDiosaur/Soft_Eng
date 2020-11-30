using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Musicorum.Tests.Mocks;
using Musicorum.Web.Controllers;
using Musicorum.Web.Models.Comment;
using System.Linq;
using Xunit;

namespace Musicorum.Tests.Web.Controllers
{
    public class CommentControllerTest
    {
        [Fact]
        public void ControllerShouldBeOnlyForAuhtorizedUsers()
        {
            var controller = typeof(CommentController);

            var attributes = controller.GetCustomAttributes(true);

            attributes
           .Should()
           .Match(attr => attr.Any(a => a.GetType() == typeof(AuthorizeAttribute)));
        }

        [Fact]
        public void CheckIfCreateMethodReturnsViewWithErrorWhenModelTextIsEmpty()
        {
            var songService = MockCreator.SongServiceMock();
            var commentService = MockCreator.CommentServiceMock();

            var controller = new CommentController(songService.Object, commentService.Object);

            var model = new SongCommentCreateModel
            {
                CommentText = ""
            };

            var result = controller.Create(model);

            result
                .Should()
                .BeOfType<ViewResult>();
        }

        [Fact]
        public void CheckIfCreateMethodReturnsRedirectWhenOk()
        {
            var songService = MockCreator.SongServiceMock();
            var commentService = MockCreator.CommentServiceMock();

            var controller = new CommentController(songService.Object, commentService.Object);

            var model = new SongCommentCreateModel
            {
                CommentText = "Test"
            };

            var result = controller.Create(model);

            result
                .Should()
                .BeOfType<RedirectToActionResult>();
        }
    }
}