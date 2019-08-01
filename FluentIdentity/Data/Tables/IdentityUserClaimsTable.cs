namespace FluentIdentity.Data.Tables
{
	public class IdentityUserClaimsTable
	{
		public virtual int Id { get; set; }

		public virtual string UserId { get; set; }
		public virtual string ClaimType { get; set; }
		public virtual string ClaimValue { get; set; }
	}
}
