using System;
using System.Collections.Generic;
using PropertyChanged;

namespace stackoverflown
{
	[ImplementPropertyChanged]
	public class AnswersListPageModel : FreshMvvm.FreshBasePageModel
	{
		public List<Answer> AnswersList { get; set; }
		public Question ThisQuestion { get; set; }
		public bool IsTableVisible { get; set; }

		IDataService _dataService;

		public AnswersListPageModel(IDataService dataService)
		{
			_dataService = dataService;
		}

		public override void Init(object initData)
		{
			ThisQuestion = initData as Question;
			IsTableVisible = true;
			AnswersList = ThisQuestion.answers;
			if (AnswersList == null)
			{
				AnswersList = new List<Answer>();
				IsTableVisible = false;
			}
			else if (AnswersList.Count == 0)
			{
				IsTableVisible = false;
			}

		}
	}
}
