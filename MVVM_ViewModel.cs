using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MVVMXamarin
{
    public class MVVM_ViewModel: INotifyPropertyChanged
    {
        private string name;
        
        public String Name
        {
            get => name;
            set
            {
                if (value == Name) return;
                name = value;
                 if (value == string.Empty) FullText = string.Empty;
                else{ FullText = $"My name is {name}"; }
                NotifyPropertyChanged();

            }
        }
        private String fullText;

        public String FullText
        {
            get { return fullText; }
            private set
            {
                if (value == FullText) return;
                fullText = value; NotifyPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
