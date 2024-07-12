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

        private MainViewModel? MainViewModel { get; set; }

        private async Task Test()
        {
            IntegrationStatusProvider integrationStatusProvider = new IntegrationStatusProvider(Configuration, HttpClient);

            List<DevOpsStatusInformation> status = await integrationStatusProvider.GetDevOpsStatusListAsync(DevOpsConfiguration.Systems[0]);

            MainViewModel mainViewModel = new MainViewModel();

            foreach (DevOpsStatusInformation statusItem in status)
            {
                StatusViewModel statusViewModel = new StatusViewModel(statusItem);

                mainViewModel.StatusViewModels.Add(statusViewModel);
            }

            MainViewModel = mainViewModel;

        }

    }
}