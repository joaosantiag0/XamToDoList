using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamToDoList.Utils;
using XamToDoList.ViewModels.Services;

namespace XamToDoList.ViewModels.Commands
{
    public class SaveTaskCommand : ICommand
    {
        private Tasks _task;
        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public async void Execute(object parameter)
        {
            var api = new Api();
            var messageService = DependencyService.Get<IMessageService>();
            var navigationService = DependencyService.Get<INavigationService>();
            if (_task?.Title == null || _task.Title.Length == 0)
            {
                await messageService.DisplayAlert("Insira o nome da tarefa", "Para salvar a tarefa é nescessário um nome.",
                    "ok");
                return;
            }

            var save = await messageService.DisplayAlert("Salvar tarefa?", $"Deseja realmente salvar a tarefa '{_task?.Title}'?", "Sim",
                "Não");

            if (save)
            {
                var req = await api.SaveTaskAsync(_task);
                if (req)
                {
                    await messageService.DisplayAlert("Sucesso!", "A Tarefa foi inserida com sucesso!", "ok");
                }
                else
                {
                    await messageService.DisplayAlert("Erro", "Ocorreu um erro ao salvar a tarefa, por favor, tente novamente!", "ok");
                }
            }
        }

        public event EventHandler CanExecuteChanged;

        public void SetTask(Tasks task)
        {
            _task = task;
        }
    }
}
