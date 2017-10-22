using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamToDoList.ViewModels.Services
{
    interface IMessageService
    {
        Task DisplayAlert(String title, String message, String cancel);
        Task<bool> DisplayAlert(String title, String message, String accept, String cancel);
    }
}
