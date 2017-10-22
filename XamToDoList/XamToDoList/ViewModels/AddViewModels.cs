using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamToDoList.Utils;
using XamToDoList.ViewModels.Commands;
using XamToDoList.ViewModels.Services;

namespace XamToDoList.ViewModels
{
    public class AddViewModels : BaseViewModel
    {
        private IMessageService _messageService;
        private Api _api;
        private Tasks _tasks;

        public Tasks Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public AddViewModels()
        {
            _messageService = DependencyService.Get<IMessageService>();
            _api = new Api();
            Tasks = new Tasks();
            var saveCmd = new SaveTaskCommand();
            saveCmd.SetTask(Tasks);
            SaveCommand = new Command(async () => await SaveTaskAsync());
        }
        
        public async Task SaveTaskAsync()
        {
            var navigationService = DependencyService.Get<INavigationService>();
            if (Tasks?.Title == null || Tasks.Title.Length == 0)
            {
                await _messageService.DisplayAlert("Insira o nome da tarefa", "Para salvar a tarefa é nescessário um nome.",
                    "ok");
                return;
            }

            var save = await _messageService.DisplayAlert("Salvar tarefa?", $"Deseja realmente salvar a tarefa '{Tasks?.Title}'?", "Sim",
                "Não");

            if (save)
            {
                var req = await _api.SaveTaskAsync(Tasks);
                if (req)
                {
                    await _messageService.DisplayAlert("Sucesso!", "A Tarefa foi inserida com sucesso!", "ok");
                }
                else
                {
                    await _messageService.DisplayAlert("Erro", "Ocorreu um erro ao salvar a tarefa, por favor, tente novamente!", "ok");
                }
            }
        }
    }
}
