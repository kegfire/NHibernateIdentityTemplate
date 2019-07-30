using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentIdentity.Data.Tables
{
	public class IdentityRoleClaimsTable
	{
		public virtual string Id { get; set; }

		public virtual string RoleId { get; set; }

		public virtual string ClaimType { get; set; }

		public virtual string ClaimValue { get; set; }
	}
}
