using BlazQuizz.Models;
using BlazQuizz.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.UI
{
    public partial class Quizz : ComponentBase
    {
        private int pos = 1;
        protected MarkupString infoPos;
        string _user;
        List<QuestionModel> Questions;


        [Inject]
        public IQuestionService _QuestionService { get; set; }
        [Inject]
        public ISharedService _SharedService { get; set; }

        [Parameter]
        public string User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
        [Parameter]
        public bool IsDisabled
        {
            get; set;
        }

        [Parameter]
        public EventCallback<ReponseModel> onAnswer { get; set; }

        protected QuestionModel? currentQuestion; 
        protected override async Task OnInitializedAsync()
        { 
            Questions = await _QuestionService.GetQuestionsAsync();
            if(Questions!=null && Questions.Count>0)
            {
                currentQuestion = Questions[0];
                infoPos = (MarkupString)$"voici la question n°{pos} "  ;
            }
        }
         

        public async Task Answer(string rep)
        {
            ReponseModel reponseModel = GenerateResponse(rep);
            _SharedService.AddReponse(reponseModel);             
            pos++;
            infoPos = (MarkupString)$"voici la question n°{pos} ";
            if (pos > Questions.Count)
            {
                await onAnswer.InvokeAsync(null);
                currentQuestion = null;
                _SharedService.Info = (MarkupString)$"Vous avez terminé! Score : {_SharedService.Reponses.Count(m=>m.IsCorrect)}/{Questions.Count()}";

            }
            else
            {

                currentQuestion = Questions[pos - 1];

            }
        }

        private ReponseModel GenerateResponse(string rep)
        {
            ReponseModel responseModel = new ReponseModel();
            responseModel.Question = Questions[pos - 1].Question;
            responseModel.Answer = rep;
            responseModel.IsCorrect = Questions[pos - 1].CorrectAnswer.ToLower() == rep.ToLower();
            return responseModel;
        }
    }
}

