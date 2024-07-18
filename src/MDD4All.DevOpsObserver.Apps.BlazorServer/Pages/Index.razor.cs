using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.StatusLightControl.Contracts;
using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace MDD4All.DevOpsObserver.Apps.BlazorServer.Pages
{
    public partial class Index
    {

        [Inject]
        IConfiguration Configuration { get; set; }

        [Inject]
        HttpClient HttpClient { get; set; }

        [Inject]
        DevOpsConfiguration DevOpsConfiguration { get; set; }

        [Inject]
        IStatusLightController StatusLightController { get; set; }

        private static MainViewModel? DataContext { get; set; }

        protected override void OnInitialized()
        {
            //Debug.WriteLine("OnInitializedCalled in Index.razor");

            DataContext = new MainViewModel(Configuration, HttpClient, DevOpsConfiguration);

            Timer timer = new System.Threading.Timer((_) =>
            {

                InvokeAsync(async () =>
                {

                    Debug.WriteLine("Timer elapsed " + DateTime.Now);

                    DataContext.RefreshStatusDataAsync();

                    //StateHasChanged();
                });
            }, null, 0, 30000);
        }

    }
}