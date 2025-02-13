namespace BlazQuizz.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using BlazQuizz.Models;
    using Microsoft.AspNetCore.Components;
    using BlazQuizz.Services.Interfaces;

    public class QuestionService : IQuestionService
    {
        private readonly HttpClient _httpClient  ;
        private readonly NavigationManager nvm;

        public QuestionService(IHttpClientFactory httpClientFactory, NavigationManager nvm)
        {

            _httpClient = httpClientFactory.CreateClient(); 
            _httpClient.BaseAddress=new Uri(nvm.BaseUri);
             
            this.nvm = nvm;
        }

        public async Task<List<QuestionModel>> GetQuestionsAsync()
        {
            try
            {                    
                QuestionList? questions = await _httpClient.GetFromJsonAsync<QuestionList>("/Data/Questions.json").ConfigureAwait(false);//ConfigureAwait permet d'éviter un deadlock lié à l'UI qui attend l'info
                return questions?.Questions ?? new List<QuestionModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement des questions : {ex.Message}");
                return new List<QuestionModel>();
            }
        }

       
    }
}
