using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentIdentity.Data.Tables
{
	public class IdentityUserTokensTable
	{
		public virtual string UserId { get; set; }

		public virtual string LoginProvider { get; set; }

		public virtual string Name { get; set; }

		public virtual string Value { get; set; }

	}
}
