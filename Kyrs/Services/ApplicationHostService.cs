using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf.Ui;

namespace Kyrs.Services
{
    public class ApplicationHostService(IServiceProvider serviceProvider) : IHostedService
    {
        private INavigationWindow? _navigationWindow;
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActionAsync();
        }
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        private async Task HandleActionAsync()
        {
            await Task.CompletedTask;
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _navigationWindow = (serviceProvider.GetService(typeof(INavigationWindow)) as INavigationWindow)!;
                _navigationWindow!.ShowWindow();
                _ = _navigationWindow.Navigate(typeof(Views.Pages.StartPage));
            }
            await Task.CompletedTask;
        }
    }
}
