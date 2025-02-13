using BlazQuizz.Models;
using BlazQuizz.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazQuizz.Components.UI
{
    public partial class Resultat : ComponentBase
    {
        [Inject]
        public ISharedService _SharedService { get; set; }

        private MarkupString _reponses;

        protected override async Task OnInitializedAsync()
        {
            _SharedService.OnDataChanged += _SharedService_OnDataChanged;
            await FillResponses(); 
        }

        private async void _SharedService_OnDataChanged()
        {
            await FillResponses();
        }
        private async Task FillResponses()
        {
            _reponses = (MarkupString)"";
            foreach (var item in _SharedService.Reponses)
            {
                await DisplayInformations(item);
            }
        }
        private Task DisplayInformations(ReponseModel info)
        {             
            _reponses = (MarkupString)(_reponses.Value + $"<hr> {info} ");
            StateHasChanged();
            return Task.CompletedTask;
        }
    }
}
