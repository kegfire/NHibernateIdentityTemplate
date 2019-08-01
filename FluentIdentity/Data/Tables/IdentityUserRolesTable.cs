namespace FluentIdentity.Data.Tables
{
	public class IdentityUserRolesTable
	{
		public virtual string UserId { get; set; }

		public virtual string RoleId { get; set; }

		public override bool Equals(object obj)
		{
			var other = obj as IdentityUserRolesTable;

			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return UserId == other.UserId &&
				RoleId == other.RoleId;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = GetType().GetHashCode();
				hash = (hash * 31) ^ UserId.GetHashCode();
				hash = (hash * 31) ^ RoleId.GetHashCode();
				return hash;
			}
		}
	}
}
