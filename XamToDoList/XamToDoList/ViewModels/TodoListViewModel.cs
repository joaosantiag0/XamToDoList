using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamToDoList.Annotations;
using XamToDoList.Utils;
using XamToDoList.ViewModels.Services;

namespace XamToDoList.ViewModels
{
    public class TodoListViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private ObservableCollection<Tasks> _toDoList;
        private bool _isLoading;
        private Tasks _selectedTasks;

        public ObservableCollection<Tasks> TodoList
        {
            get => _toDoList ?? new ObservableCollection<Tasks>();
            set
            {
                _toDoList = value;
                OnPropertyChanged();
            }
        }


        public Tasks SelectedTasks
        {
            get => _selectedTasks;
            set
            {
                _selectedTasks = value;
                OnPropertyChanged();
                new Commons().DialogDoneTask(_selectedTasks);

            }
        }

        public ICommand AddTaskCommand { get; set; }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public TodoListViewModel()
        {
            _navigationService = DependencyService.Get<INavigationService>();
            IsLoading = true;
            TodoList = new ObservableCollection<Tasks>();
            AddTaskCommand = new Command(AddTask);
        }

        private void AddTask()
        {
            _navigationService.GoToAdd();
        }

    }
}