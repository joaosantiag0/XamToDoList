using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamToDoList.ViewModels;
using XamToDoList.ViewModels.Services;

namespace XamToDoList.Utils
{
    public class Commons
    {
        public async Task DialogDoneTask(Tasks task)
        {
            if(task == null) return;
            var messageService = DependencyService.Get<IMessageService>();

            var prompt = await messageService.DisplayAlert("Finalizou esta tarefa?",
                $"Deseja marcar a tarefa '{task?.Title}' como finalizada?", "Sim", "Não");
            if (prompt)
            {
                task.Done = true;
            }
        }
    }
}
