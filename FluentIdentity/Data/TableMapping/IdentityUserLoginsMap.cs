using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityUserLoginsMap : ClassMap<IdentityUserLoginsTable>
	{
		public IdentityUserLoginsMap()
		{
			Map(x => x.LoginProvider).Length(128);
			Map(x => x.ProviderKey).Length(128);
			CompositeId()
				.KeyProperty(x => x.LoginProvider)
				.KeyProperty(x => x.ProviderKey);
			Map(x => x.ProviderDisplayName);
			Map(x => x.UserId).UniqueKey("UserId").Index("UserId");
		}
	}
}
