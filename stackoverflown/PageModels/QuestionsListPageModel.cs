using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropertyChanged;

namespace stackoverflown
{
	[ImplementPropertyChanged]
	public class QuestionsListPageModel : FreshMvvm.FreshBasePageModel
	{
		public List<Question> QuestionsList { get; set; }

		public bool IsBusy { get; private set; }

		public bool IsTableEnabled { get; private set; }

		IDataService _dataService;

		public QuestionsListPageModel(IDataService dataService)
		{
			_dataService = dataService;
		}



		public override async void Init(object initData)
		{
			base.Init(initData);

			//QuestionsList = new List<Question> {
			//	new Question { Text="Dummy text 1", AnswersCount=0, Author="Dummy author", Title="Question title 1", CreationDate=DateTime.Now, ModificationDate=DateTime.Now },
			//	new Question { Text="Dummy text 2", AnswersCount=0, Author="Dummy author", Title="Question title 2", CreationDate=DateTime.Now, ModificationDate=DateTime.Now },
			//	new Question { Text="Dummy text 3", AnswersCount=0, Author="Dummy author", Title="Question title 3", CreationDate=DateTime.Now, ModificationDate=DateTime.Now }
			//};
			IsBusy = true;
			IsTableEnabled = false;
			QuestionsList = await _dataService.getDataFromService("xamarin");
			IsBusy = false;
			IsTableEnabled = true;
		}
	}
}
