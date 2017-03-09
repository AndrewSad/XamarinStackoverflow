using Xamarin.Forms;
using FreshMvvm;

namespace stackoverflown
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			SetupIOC();

			var firstPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<QuestionsListPageModel>();

			var navPage = new FreshMvvm.FreshNavigationContainer(firstPage);

			MainPage = navPage;
		}

		void SetupIOC()
		{
			FreshIOC.Container.Register<IDataService, DataService>();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
