using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using Prism.Navigation;
using XamarinFormsPrism.Services;

namespace XamarinFormsPrism.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware
    {
        private readonly ISomeService _someService;
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand DoAnything { get; set; }
        public DelegateCommand NavigateToMainPage { get; set; }

        public SecondPageViewModel(ISomeService someService, INavigationService navigationService)
        {
            _someService = someService;
            _navigationService = navigationService;
            
            DoAnything = new DelegateCommand(InvokeDoAnything);
            NavigateToMainPage = new DelegateCommand(async () => await InvokeNavigateToMainPage());
        }
        
        private void InvokeDoAnything()
        {
            _someService.DoAnything();
        }

        private async Task InvokeNavigateToMainPage()
        {
            await _navigationService.NavigateAsync("pl.softwarehut.XamarinFormsPrism:///MainPage");
            //await _navigationService.NavigateAsync("XamarinFormsPrism:///MainPage");
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("SecondPageViewModel OnNavigatedFrom");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine("SecondPageViewModel OnNavigatedTo");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("customParameter"))
                Title = (string)parameters["customParameter"];
            System.Diagnostics.Debug.WriteLine("SecondPageViewModel OnNavigatingTo");
        }
    }
}
