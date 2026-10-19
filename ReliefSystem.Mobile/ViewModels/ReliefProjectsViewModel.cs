using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ReliefSystem.Mobile.Models;
using ReliefSystem.Mobile.Services;

namespace ReliefSystem.Mobile.ViewModels
{
    public class ReliefProjectsViewModel : INotifyPropertyChanged
    {
        private readonly ApiService _apiService;
        private bool _isRefreshing;

        public ObservableCollection<ReliefProject> Projects { get; set; } = new();

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadProjectsCommand { get; }

        public ReliefProjectsViewModel()
        {
            _apiService = new ApiService();
            LoadProjectsCommand = new RelayCommand(async () => await LoadProjectsAsync());

            // Initial load
            _ = LoadProjectsAsync();
        }

        public async Task LoadProjectsAsync()
        {
            if (IsRefreshing) return;

            try
            {
                IsRefreshing = true;
                var projectsList = await _apiService.GetReliefProjectsAsync();

                Projects.Clear();
                foreach (var project in projectsList)
                {
                    Projects.Add(project);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading projects: {ex.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Lightweight RelayCommand implementation for standard .NET compatibility
    public class RelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool>? _canExecute;

        public RelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        public async void Execute(object? parameter) => await _execute();
    }
}