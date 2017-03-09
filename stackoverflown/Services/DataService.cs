using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace stackoverflown
{
	public class DataService : IDataService
    {
		public async Task<ObservableCollection<Question>> getQuestionsFromService(string queryString)
        {
			dynamic response;
			var questions = new ObservableCollection<Question>();
			var handler = new HttpClientHandler();
			if (handler.SupportsAutomaticDecompression)
				handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

			var httpClient = new HttpClient(handler);

			response = await httpClient.GetAsync(string.Format(Constants.stackoverflowQuery, queryString));
			JObject data = null;
			try
			{
				if (response != null)
				{
					string json = response.Content.ReadAsStringAsync().Result;
					data = JObject.Parse(json);
				}
				else {
					data = new JObject();
				}

				var items = data["items"];
				if (items != null)
				{
					foreach (var item in items)
					{
						var aQuestion = new Question();
						aQuestion = JsonConvert.DeserializeObject<Question>(item.ToString());

						Debug.WriteLine("Author: {0}, Title: {1}, Answer count: {2}", aQuestion.owner.display_name, aQuestion.title, aQuestion.answer_count);
						questions.Add(aQuestion);
					}
				}
			}

			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());

				var aQuestion = new Question();

				questions.Add(aQuestion);
			}

			return questions;

        }

		public async Task<List<Answer>> getAnswersFromService(string answer_id)
		{
			var answers = new List<Answer>();
			var handler = new HttpClientHandler();
			if (handler.SupportsAutomaticDecompression)
				handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

			var httpClient = new HttpClient(handler);

			dynamic response = await httpClient.GetAsync(string.Format(Constants.stackoverflowAnswersQuery, answer_id));

			return answers;
		}


    }
}