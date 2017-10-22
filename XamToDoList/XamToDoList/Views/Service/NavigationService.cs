using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamToDoList.ViewModels.Services;

namespace XamToDoList.Views.Service
{
    public class NavigationService : INavigationService
    {
        public async Task GoToHome()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        public async Task GoToAdd()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddPage());
        }
    }
}
