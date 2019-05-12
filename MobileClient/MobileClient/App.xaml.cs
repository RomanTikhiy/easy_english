using Prism;
using Prism.Ioc;
using MobileClient.ViewModels;
using MobileClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tesseract;
using MobileClient.Abstractions;
using MobileClient.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileClient
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("MyMasterDetailPage/MyNavigationPage/MainPage");
            await NavigationService.NavigateAsync("LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry container)
        {
            container.Register<ITranslator, Translator>();

            container.RegisterForNavigation<MyNavigationPage>();
            container.RegisterForNavigation<MainPage, MainPageViewModel>();
            container.RegisterForNavigation<MyMasterDetailPage, MyMasterDetailPageViewModel>();
            container.RegisterForNavigation<VocabulariesPage, VocabulariesViewModel>();
            container.RegisterForNavigation<VocabularyPageDetail, VocabularyPageDetailViewModel>();
            container.RegisterForNavigation<WordPageDetail, WordPageDetailViewModel>();
            container.RegisterForNavigation<EditVocabularyPage, EditVocabularyViewModel>();
            container.RegisterForNavigation<CameraTranslatePage, CameraTranslateViewModel>();
            container.RegisterForNavigation<TranslatePage, TranslatePageViewModel>();
            container.RegisterForNavigation<TestsPage, TestsViewModel>();
            container.RegisterForNavigation<GrammarTestPage, GrammarTestViewModel>();
            container.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}
