using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XamToDoList.Utils;
using XamToDoList.ViewModels;

namespace XamToDoList
{
    public partial class MainPage : ContentPage
    {
        private TodoListViewModel _model;
        public MainPage()
        {
            InitializeComponent();
            _model = new TodoListViewModel();
            BindingContext = _model;
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var api = new Api();
            var todoList = await api.GetListTasksAsync(_model);
            _model.TodoList = new ObservableCollection<Tasks>();
            todoList.ForEach(p => _model.TodoList.Add(p));
        }
    }
}