using AutoMapper;
using Musicorum.Common.Mapping;
using Musicorum.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Musicorum.Services.Models
{
    public class UserAccountModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public byte[] ProfilePicture { get; set; }

        public IEnumerable<EventModel> Events { get; set; } = new List<EventModel>();

        public IList<SongModel> LikedSongs { get; set; }
        public IList<SongModel> UserSongs { get; set; }

    }
}