namespace FluentIdentity.Data.Tables
{
	public class IdentityUserTokensTable
	{
		public virtual string UserId { get; set; }

		public virtual string LoginProvider { get; set; }

		public virtual string Name { get; set; }

		public virtual string Value { get; set; }

		public override bool Equals(object obj)
		{
			var other = obj as IdentityUserTokensTable;

			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return UserId == other.UserId &&
				LoginProvider == other.LoginProvider &&
				Name == other.Name;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = GetType().GetHashCode();
				hash = (hash * 31) ^ UserId.GetHashCode();
				hash = (hash * 31) ^ LoginProvider.GetHashCode();
				hash = (hash * 31) ^ Name.GetHashCode();
				return hash;
			}
		}
	}

}
