using AutoService.ViewModel.Command;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoService.ViewModel.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public Action Close { get; set; }

        public RelayCommand CloseCommand
        {
            get
            {
                return new RelayCommand((o) => Close());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
