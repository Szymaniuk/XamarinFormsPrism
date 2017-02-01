using Prism.Unity;
using XamarinFormsPrism.Views;

namespace XamarinFormsPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
