using ReliefSystem.Mobile.ViewModels;

namespace ReliefSystem.Mobile.Views
{
    public partial class ReliefProjectsPage : ContentPage
    {
        public ReliefProjectsPage()
        {
            InitializeComponent();
            BindingContext = new ReliefProjectsViewModel();
        }
    }
}