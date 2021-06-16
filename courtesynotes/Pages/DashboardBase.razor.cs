using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;

namespace courtesynotes.Pages
{
    public class DashboardBase : ComponentBase
    {
        [Inject] protected ISessionStorageService StorageService { get; set; }
        protected string SessionEmail;
        protected override async Task OnInitializedAsync()
        {
            SessionEmail = await StorageService.GetItemAsync<string>("_username");
        }
    }
}
