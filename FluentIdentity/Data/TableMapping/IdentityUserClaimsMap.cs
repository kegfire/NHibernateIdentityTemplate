using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;
using System;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityUserClaimsMap : ClassMap<IdentityUserClaimsTable>
	{
		public IdentityUserClaimsMap()
		{
			Id(x => x.Id).GeneratedBy.Custom<CustomIdentityGenerator>(p => p.AddParam("Id", Guid.NewGuid().ToString()));
			Map(x => x.UserId).Not.Nullable();
			Map(x => x.ClaimType).Nullable();
			Map(x => x.ClaimValue).Nullable();
		}
	}
}
