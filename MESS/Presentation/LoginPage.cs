namespace MESS.Presentation;

public sealed partial class LoginPage : Page
{
	public LoginPage()
	{
		Content = new Grid
		{
			Children =
			{
				new TextBlock
				{
					Name = "LoginViewTitle",
					Text = "Login",
					FontSize = 24,
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				}
			}
		};
	}
}
