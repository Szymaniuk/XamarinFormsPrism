using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace XamarinFormsPrism.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateToSecondPage { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToSecondPage = new DelegateCommand(InvokeNavigateToSecondPage);
        }

        private void InvokeNavigateToSecondPage()
        {
            _navigationService.NavigateAsync("SecondPage?customParameter=Test123");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("MainPageViewModel OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("MainPageViewModel OnNavigatedTo");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"];
            System.Diagnostics.Debug.WriteLine("MainPageViewModel OnNavigatingTo");
        }
    }
}
