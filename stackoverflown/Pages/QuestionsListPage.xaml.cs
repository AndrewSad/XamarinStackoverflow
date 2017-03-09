using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace stackoverflown
{
	public partial class QuestionsListPage : ContentPage
	{
		public QuestionsListPage()
		{
			InitializeComponent();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			QuestionsList.SelectedItem = null;
		}
	}
}
