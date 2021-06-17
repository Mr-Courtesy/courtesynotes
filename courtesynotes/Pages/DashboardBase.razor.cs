using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using courtesynotes.Data;
using Google.Cloud.Firestore;
using courtesynotes.Models;
using Blazored.Modal.Services;
using Blazored.Modal;
using courtesynotes.Components;

namespace courtesynotes.Pages
{
    public class DashboardBase : ComponentBase
    {
        [Inject] protected IModalService Modal { get; set; }
        [Inject] protected ISessionStorageService StorageService { get; set; }
        [Inject] protected IModalService ModalService { get; set; }
        protected string SessionEmail;
        protected string CourseName;
        protected override async Task OnInitializedAsync()
        {
            SessionEmail = await StorageService.GetItemAsync<string>("_username");
        }
        protected async Task AddCourse()
        {
            Modal.Show<CourseComponent>("Add a course");
        }
    }
}
