using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace flashcard_mobile.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool isBusy;
        [ObservableProperty]
        public string title;
    }
}
