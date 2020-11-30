using AutoMapper;
using Musicorum.Web.Infrastructure.Mapping;

namespace Musicorum.Tests.Common
{
    public static class Initializer
    {
        public static void IniializeAuttoMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
        }
    }
}