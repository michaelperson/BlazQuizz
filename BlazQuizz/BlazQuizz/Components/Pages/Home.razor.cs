using BlazQuizz.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;

namespace BlazQuizz.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private NavigationManager nvm { get;set; }
         
        private bool _IsDisabled = false;
        private string Nom = string.Empty;
        private void IsFinished()
        {
            _IsDisabled = true;
            nvm.NavigateTo( $"Fin/{Nom}", forceLoad: true);
        }
 
    }
}
