using Microsoft.EntityFrameworkCore;
using Moq;
using Musicorum.Data;
using Musicorum.Services.Implementations;
using System;

namespace Musicorum.Tests.Mocks
{
    public class MockCreator
    {
        public static MusicorumDbContext GetDb()
        {
            var dbOptions = new DbContextOptionsBuilder<MusicorumDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new MusicorumDbContext(dbOptions);
        }

        public static Mock<UserService> UserServiceMock()
        {
            return new Mock<UserService>(GetDb(), null, null, null);
        }

        public static Mock<SongService> SongServiceMock()
        {
            return new Mock<SongService>(GetDb(), null, null);
        }

        public static Mock<CommentService> CommentServiceMock()
        {
            return new Mock<CommentService>(GetDb());
        }
    }
}