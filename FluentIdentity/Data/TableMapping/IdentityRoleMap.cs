using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityRoleMap : ClassMap<IdentityRoleTable>
	{
		public IdentityRoleMap()
		{
			Id(x => x.Id).GeneratedBy.Guid();
			Map(x => x.Name).Length(256).Nullable();
			Map(x => x.NormalizedName).Length(256).Nullable().Index("RoleNameIndex");
			Map(x => x.ConcurrencyStamp).Nullable();

			HasMany(x => x.IdentityUserRoles).KeyColumn("UserId");
			HasMany(x => x.IdentityRoleClaims).KeyColumn("RoleId");
		}
	}
}
