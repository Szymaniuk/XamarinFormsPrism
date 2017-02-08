using Prism.Unity;
using Xamarin.Forms.Xaml;
using XamarinFormsPrism.Services;
using XamarinFormsPrism.Views;
using Microsoft.Practices.Unity;

namespace XamarinFormsPrism
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello SH, from XF Prism");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<SecondPage>();
            
            Container.RegisterType<ISomeService, SomeServiceImpl>();
        }
    }
}
