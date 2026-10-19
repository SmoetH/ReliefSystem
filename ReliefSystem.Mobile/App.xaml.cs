using ReliefSystem.Mobile.Views;

namespace ReliefSystem.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Wrap LoginPage in a NavigationPage so PushAsync works
            MainPage = new NavigationPage(new LoginPage());
        }
    }
}