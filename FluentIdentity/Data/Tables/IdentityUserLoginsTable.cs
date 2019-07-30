namespace FluentIdentity.Data.Tables
{
	public class IdentityUserLoginsTable
	{
		public virtual string LoginProvider { get; set; }

		public virtual string ProviderKey { get; set; }

		public virtual string ProviderDisplayName { get; set; }

		public virtual string UserId { get; set; }
	}
}
