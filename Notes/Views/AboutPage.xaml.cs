namespace Notes.Views;
public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
    }
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        //BrowserTests browserTests = new BrowserTests();
        //browserTests.Setup();
        //browserTests.Test_GoogleSearch();
        //browserTests.Teardown();
        LoginTests loginTests = new LoginTests();
        loginTests.Setup();
        loginTests.Test_Login();
        loginTests.Teardown();


        if (BindingContext is Models.About about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }
}