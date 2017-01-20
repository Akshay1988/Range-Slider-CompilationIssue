// App.xaml.cs
//
//  Author:
//       Nisha <NThakur6@slb.com>
//
//  Copyright (c) 2017 Nisha
using Xamarin.Forms;

namespace RangeSliderIssue
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new RangeSliderIssuePage();
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
