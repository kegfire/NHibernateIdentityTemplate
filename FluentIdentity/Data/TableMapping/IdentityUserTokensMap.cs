using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;

namespace FluentIdentity.Data.TableMapping
{
	public class IdentityUserTokensMap : ClassMap<IdentityUserTokensTable>
	{
		public IdentityUserTokensMap()
		{
			Map(x => x.UserId);
			Map(x => x.LoginProvider).Length(128);
			Map(x => x.Name).Length(128);
			Map(x => x.Value).Nullable();
			CompositeId()
				.KeyProperty(x => x.UserId)
				.KeyProperty(x => x.LoginProvider)
				.KeyProperty(x => x.Name);
		}
	}
}
