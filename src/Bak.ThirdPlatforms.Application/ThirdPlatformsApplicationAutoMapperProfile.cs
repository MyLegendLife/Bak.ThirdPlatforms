using AutoMapper;
using Bak.ThirdPlatforms.Application.Contracts.Auths;
using Bak.ThirdPlatforms.Application.Contracts.MiniPrograms;
using Bak.ThirdPlatforms.Domain.Auths;
using Bak.ThirdPlatforms.Domain.MiniPrograms;

namespace Bak.ThirdPlatforms.Application
{
    public class ThirdPlatformsApplicationAutoMapperProfile : Profile
    {
        public ThirdPlatformsApplicationAutoMapperProfile()
        {
            CreateMap<MiniProgramRegisterInput, MiniProgramRecord>()
                .ForMember(x => x.Id, map => map.Ignore())
                .ForMember(x => x.errcode, map => map.Ignore())
                .ForMember(x => x.errmsg, map => map.Ignore())
                .ForMember(x => x.CreationTime, map => map.Ignore())
                .ForMember(x => x.LastModificationTime, map => map.Ignore());

            CreateMap<MiniProgramRecord, MiniProgramRecordDto>();

            CreateMap<Authorizer, AuthorizerDto>();
        }
    }
}
