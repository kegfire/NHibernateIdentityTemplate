namespace FluentIdentity.Data.Tables
{
	public class IdentityUserLoginsTable
	{
		public virtual string LoginProvider { get; set; }

		public virtual string ProviderKey { get; set; }

		public virtual string ProviderDisplayName { get; set; }

		public virtual string UserId { get; set; }

		public override bool Equals(object obj)
		{
			var other = obj as IdentityUserLoginsTable;

			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return UserId == other.UserId &&
				LoginProvider == other.LoginProvider;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = GetType().GetHashCode();
				hash = (hash * 31) ^ UserId.GetHashCode();
				hash = (hash * 31) ^ LoginProvider.GetHashCode();
				return hash;
			}
		}
	}
}
