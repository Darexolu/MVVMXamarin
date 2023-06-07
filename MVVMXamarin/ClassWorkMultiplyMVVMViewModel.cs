using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMXamarin
{
    public class ClassWorkMultiplyMVVMViewModel: BaseMVVM
    {

        private int firstnumber;
        public int FirstNumber
        {
            get
            {
                return firstnumber;
            }
            set
            {   if (value != firstnumber)
                {
                    firstnumber = value;
                    displayResult = multiplyNumber();
                    NotifyPropertyChanged();
                }
            }
        }
        private int secondnumber;
        public int SecondNumber
        {
            get
            {
                return secondnumber;
            }
            set
            {    if(value != secondnumber) { 
                secondnumber = value;
                DisplayResult = multiplyNumber();
                NotifyPropertyChanged();
                }
            }

            // set property used when there are other logic to perform in the set accessor
        //     public int One
        //{
        //    get => one; set
        //    {
        //        if (SetProperty(ref one, value))
        //        {
        //            // Do something with the new value.
        //            Three = Update();

        //        }
            }
        private int displayResult;

        public int DisplayResult { get => displayResult; set { SetProperty(ref displayResult, value); } }
        //{
        //    get
        //    {
        //        return displayResult;
        //    }
        //    set
        //    {
        //        displayResult = value;
        //        NotifyPropertyChanged();

        //    }

        //}

        //private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private int multiplyNumber()
        { int firstNumber = FirstNumber;
            int secondNumber = SecondNumber;
            int multiplication = firstNumber * secondNumber;
            return multiplication;
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        //{ if (Object.Equals(storage, value)) return false; 
        //    storage = value;
        //    NotifyPropertyChanged(propertyName);
        //    return true; 
        //}
        //private List<Color> someColor = new List<Color> { Color.AliceBlue, Color.Pink, Color.SaddleBrown, Color.Firebrick };
        //public ICommand ChangeOne { get => new Command<int>((parameter) => One += parameter); }
        public ICommand ChangeOne { get => new Command<string>((parameter) => FirstNumber += int.Parse(parameter) * SecondNumber); }
    }
}
