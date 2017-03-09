using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace stackoverflown
{
	public interface IDataService
	{
		Task<ObservableCollection<Question>> getQuestionsFromService(string queryString);
	}
}
