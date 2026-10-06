namespace MESS.Presentation;

public sealed partial class UsersPage : Page
{
	public UsersPage()
	{
		Content = new Grid
		{
			Children =
			{
				new TextBlock
				{
					Name = "UsersViewTitle",
					Text = "Users",
					FontSize = 24,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				}
			}
		};
	}
}
