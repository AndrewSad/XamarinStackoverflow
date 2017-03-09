using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using Xamarin.Forms;

namespace stackoverflown
{
	[ImplementPropertyChanged]
	public class QuestionsListPageModel : FreshMvvm.FreshBasePageModel
	{
		public ObservableCollection<Question> QuestionsList { get; set; }

		public bool IsBusy { get; private set; }

		public bool IsTableEnabled { get; private set; }

		public bool IsRefreshing { get; set; }

		public bool PickerVisible { get; set; }

		public string SelectedTag { get; set; }

		IDataService _dataService;

		public QuestionsListPageModel(IDataService dataService)
		{
			_dataService = dataService;
		}

		Question _selectedQuestion;

		public Question SelectedQuestion
		{
			get
			{
				return _selectedQuestion;
			}
			set
			{
				_selectedQuestion = value;
				if (value != null)
					QuestionSelected.Execute(value);
			}
		}

		public Command<Question> QuestionSelected {
        get {
				return new Command<Question>(async(question) => {
					await CoreMethods.PushPageModel<AnswersListPageModel>(question);
            });
        }
    }

		public override async void Init(object initData)
		{
			base.Init(initData);

			//QuestionsList = new List<Question> {
			//	new Question { Text="Dummy text 1", AnswersCount=0, Author="Dummy author", Title="Question title 1", CreationDate=DateTime.Now, ModificationDate=DateTime.Now },
			//	new Question { Text="Dummy text 2", AnswersCount=0, Author="Dummy author", Title="Question title 2", CreationDate=DateTime.Now, ModificationDate=DateTime.Now },
			//	new Question { Text="Dummy text 3", AnswersCount=0, Author="Dummy author", Title="Question title 3", CreationDate=DateTime.Now, ModificationDate=DateTime.Now }
			//};
			PickerVisible = false;
			SelectedTag = "xamarin";
			IsBusy = true;
			IsTableEnabled = false;
			QuestionsList = await _dataService.getQuestionsFromService("xamarin");
			IsBusy = false;
			IsTableEnabled = true;
		}

		//public ICommand ShowPickerCommand()
		//{
			
		//}
	}
}
