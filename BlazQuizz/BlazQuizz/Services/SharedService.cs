using BlazQuizz.Models;
using BlazQuizz.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazQuizz.Services
{
    public class SharedService : ISharedService
    {
        private List<ReponseModel> _reponses = new List<ReponseModel>();
        public MarkupString Info { get; set; }
        public List<ReponseModel> Reponses
        {
            get { return _reponses; }
        }

        public event Action OnDataChanged;

        public void AddReponse(ReponseModel reponse)
        {
            _reponses.Add(reponse);
            OnDataChanged?.Invoke();
        }
    }
}
