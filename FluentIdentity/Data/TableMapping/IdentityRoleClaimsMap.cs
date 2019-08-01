using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityRoleClaimsMap : ClassMap<IdentityRoleClaimsTable>
	{
		public IdentityRoleClaimsMap()
		{
			Id(x => x.Id).GeneratedBy.Increment();
			Map(x => x.RoleId).Not.Nullable();
			Map(x => x.ClaimType).Nullable();
			Map(x => x.ClaimValue).Nullable();
		}
	}
}
