using Bak.ThirdPlatforms.Domain.Auths;
using Bak.ThirdPlatforms.Domain.Base;
using Bak.ThirdPlatforms.Domain.MiniPrograms;
using Bak.ThirdPlatforms.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Bak.ThirdPlatforms.EntityFrameworkCore.EntityFrameworkCore
{
    public static class ThirdPlatformsDbContextModelCreatingExtensions
    {
        public static void ConfigureThirdPlatforms(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<ThirdTicket>(b =>
            {
                b.ToTable("Wx_SmallProgramThirdTicketInfo");
                b.HasKey(x => x.ThirdAppID);
            });

            //builder.Entity<ThirdAccessToken>(b =>
            //{
            //    b.ToTable(ThirdPlatformsConsts.DbTablePrefix + "SmallProgramThirdAccessTokenInfo");
            //    b.HasKey(x => x.ThirdAppID);
            //});

            //builder.Entity<MerchanAuthorization>(b =>
            //{
            //    b.ToTable(ThirdPlatformsConsts.DbTablePrefix + "SmallProgramMerchantAuthorizationInfo");
            //    b.HasKey(x => new { x.ThirdAppID, x.AppID });
            //});

            builder.Entity<Factor>(b =>
            {
                b.ToTable(ThirdPlatformsConsts.DbTablePrefix + "Factors");
                b.HasKey(x => x.Id);
            });

            builder.Entity<Authorizer>(b =>
            {
                b.ToTable(ThirdPlatformsConsts.DbTablePrefix + "Authorizers");
                b.HasKey(x => x.Id);
            });

            builder.Entity<MiniProgramRecord>(b =>
            {
                b.ToTable(ThirdPlatformsConsts.DbTablePrefix + "MiniProgramRecords");
                b.HasKey(x => x.Id);
            });


            //builder.Entity<Merchan>(b =>
            //{
            //    b.ToTable(ThirdPlatformsConsts.DbTablePrefix + "SmallProgramMerchanInfo");
            //    b.HasKey(x => new { x.ThirdAppID, x.AppID });
            //});

            //builder.Entity<Order>(b =>
            //{
            //    b.ToTable(ThirdPlatformsConsts.DbTablePrefix + nameof(Order) + ThirdPlatformsConsts.DbTableSuffix);
            //    b.HasKey(x => x.Id);
            //    b.ConfigureByConvention(); 
            //    b.Property(x => x.UserNo).HasMaxLength(20).IsRequired();
            //    b.Property(x => x.OrderNo).IsRequired();
            //    b.Property(x => x.Type).IsRequired();
            //    b.Property(x => x.CreationTime).IsRequired();
            //});

            //builder.Entity<OrderLine>(b =>
            //{
            //    b.ToTable(ThirdPlatformsConsts.DbTablePrefix + nameof(OrderLine) + ThirdPlatformsConsts.DbTableSuffix);
            //    b.HasKey(x => new{x.OrderId, x.ProductNo});
            //    b.ConfigureByConvention();
            //    b.Property(x => x.ProductNo).HasMaxLength(200);
            //    b.Property(x => x.ProductName).HasMaxLength(200);
            //});
        }
    }
}