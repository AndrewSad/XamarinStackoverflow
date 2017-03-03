using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace stackoverflown
{
	public interface IDataService
	{
		Task<List<Question>> getDataFromService(string queryString);
	}
}
