using Bak.ThirdPlatforms.Domain.Auths;
using Bak.ThirdPlatforms.Domain.Auths.Repositories;
using Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.Repositories.Auths
{
    public class AuthorizerRepository : EfCoreRepository<ThirdPlatformsDbContext, Authorizer,int>, IAuthorizerRepository
    {
        public AuthorizerRepository(IDbContextProvider<ThirdPlatformsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}