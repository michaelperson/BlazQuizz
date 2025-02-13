using BlazQuizz.Models;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Services.Interfaces
{
    public interface ISharedService
    {
        event Action OnDataChanged;
        List<ReponseModel> Reponses
        {
            get;
        }
        MarkupString Info { get; set; }
        void AddReponse(ReponseModel reponse);
    }
}