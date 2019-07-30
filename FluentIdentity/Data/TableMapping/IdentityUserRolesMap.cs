using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityUserRolesMap : ClassMap<IdentityUserRolesTable>
	{
		public IdentityUserRolesMap()
		{
			Map(x => x.UserId).Length(128);
			Map(x => x.RoleId).Length(128).Index("RoleId");
			CompositeId()
				.KeyProperty(x => x.RoleId)
				.KeyProperty(x => x.UserId);


		}
	}
}
