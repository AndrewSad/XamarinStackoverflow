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

			MainPage = FreshMvvm.FreshPageModelResolver.ResolvePageModel<QuestionsListPageModel>();
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
