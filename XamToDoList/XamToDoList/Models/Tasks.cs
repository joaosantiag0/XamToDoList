using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using XamToDoList.Annotations;
using XamToDoList.Models;

namespace XamToDoList.ViewModels
{
    public class Tasks : BaseModel
    {
        private string _title;
        private bool _done;


        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool Done
        {
            get => _done;
            set
            {
                _done = value;
                OnPropertyChanged();
            }
        }


    }
}