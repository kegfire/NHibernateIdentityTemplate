using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityUsersMap : ClassMap<IdentityUsersTable>
	{
		public IdentityUsersMap()
		{
			Id(x => x.Id).GeneratedBy.Custom<CustomIdentityGenerator>(p => p.AddParam("Id", Guid.NewGuid().ToString()));
			Map(x => x.UserName).Length(256).Nullable();
			Map(x => x.NormalizedUserName).Length(256).Index("UserNameIndex").Nullable();
			Map(x => x.Email).Length(256).Nullable();
			Map(x => x.NormalizedEmail).Length(256).Index("EmailIndex").Nullable();
			Map(x => x.EmailConfirmed);
			Map(x => x.PasswordHash).Nullable();
			Map(x => x.SecurityStamp).Nullable();
			Map(x => x.ConcurrencyStamp).Nullable();
			Map(x => x.PhoneNumber).Nullable();
			Map(x => x.PhoneNumberConfirmed);
			Map(x => x.TwoFactorEnabled);
			Map(x => x.LockoutEnd).Nullable();
			Map(x => x.LockoutEnabled);
			Map(x => x.AccessFailedCount);

			HasMany(x => x.IdentityUserLogins).KeyColumn("UserId");
			HasMany(x => x.IdentityUserClaims).KeyColumn("UserId");
			HasMany(x => x.IdentityUserRoles).KeyColumn("UserId");
			HasMany(x => x.IdentityUserTokens).KeyColumn("UserId");
		}
	}
}
