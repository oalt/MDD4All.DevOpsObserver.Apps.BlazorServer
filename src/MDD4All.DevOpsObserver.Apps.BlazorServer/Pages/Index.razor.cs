using MDD4All.DevOpsObserver.DataModels;
using MDD4All.DevOpsObserver.DataProviders.Integration;
using MDD4All.DevOpsObserver.ViewModels;
using Microsoft.AspNetCore.Components;

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

        private MainViewModel? DataContext { get; set; }

        protected override void OnInitialized()
        {
            DataContext = new MainViewModel(Configuration, HttpClient, DevOpsConfiguration);
        }

    }
}