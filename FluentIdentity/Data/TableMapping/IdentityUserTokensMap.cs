using FluentIdentity.Data.Tables;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		}
	}
}
