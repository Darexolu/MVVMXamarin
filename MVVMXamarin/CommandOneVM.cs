using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMXamarin
{
    public class CommandOneVM : BaseMVVM
    {
        private Color bgColor = Color.Red;
        public Color BgColor { get => bgColor; set { SetProperty(ref bgColor, value); } }
        //Option One
        //public ICommand ChangeBG { get => new Command(() => BgColor = bgColor == Color.Red? Color.Blue: Color.Red); }

        //OPtion Two
        public ICommand ChangeBG { get; private set; }

        public CommandOneVM()
        {
           //OPtion Two
           //ChangeBG = new Command(() => BgColor = bgColor == Color.Red ? Color.Blue : Color.Red);

        //    //Option Three
           ChangeBG = new Command(
               execute: () => BgColor = bgColor == Color.Red ? Color.Blue : Color.Red,

               canExecute: () => { return entryNumber % 2 == 00; }


               );

        }

        //int x = 2;
        //public int SamplePPty { get => x == 2 ? 4 : 5; }
        int entryNumber;
        public int EntryNumber
        {
            get => entryNumber;
           //Option Three
           //set { if (entryNumber == value) return; entryNumber = value; (ChangeBG as Command).ChangeCanExecute(); }
           set
           {
               if (SetProperty(ref entryNumber, value))
                   (ChangeBG as Command).ChangeCanExecute();
           }
        }
    }
}
