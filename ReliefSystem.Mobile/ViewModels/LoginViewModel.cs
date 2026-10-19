using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ReliefSystem.Mobile.Services;
using ReliefSystem.Mobile.Views;

namespace ReliefSystem.Mobile.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;
        private bool _isLoading;

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set { _errorMessage = value; OnPropertyChanged(); }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _apiService = new ApiService();
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        private async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Please enter both email and password.";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;

            try
            {
                var token = await _apiService.LoginAsync(Email, Password);

                if (!string.IsNullOrEmpty(token))
                {
                    ErrorMessage = "Login successful!";
                    System.Diagnostics.Debug.WriteLine($"JWT Token: {token}");

                    // Navigate to the Relief Projects page on success
                    await Application.Current.MainPage.Navigation.PushAsync(new ReliefProjectsPage());
                }
                else
                {
                    ErrorMessage = "Invalid credentials or server error.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}