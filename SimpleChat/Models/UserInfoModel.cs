namespace SimpleChat.Models
{
	public sealed class UserInfoModel
	{
		public string Name { get; set; }

		public UserInfoModel(string name)
		{
			Name = name;
		}
	}
}