using System.Collections.Generic;

namespace FluentIdentity.Data.Tables
{
	public class IdentityRolesTable
	{
		public virtual string Id { get; set; }

		public virtual string Name { get; set; }

		public virtual string NormalizedName { get; set; }

		public virtual string ConcurrencyStamp { get; set; }

		public virtual IList<IdentityUserRolesTable> IdentityUserRoles { get; set; }

		public virtual IList<IdentityRoleClaimsTable> IdentityRoleClaims { get; set; }
	}
}
