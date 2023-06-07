using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVMXamarin
{
    public class WatchViewModel: BaseMVVM
    {
        private int enterMins;
        public int EnterMins { get => enterMins; set { 
                if(EnterMins != value)
                {
                    enterMins = value;
                    Timer = $"{DigitDoubler(enterMins)} : {DigitDoubler(enterSecs)}";

                }; } }

        private int enterSecs;
        public int EnterSecs { get => enterSecs; set
            {
                if(EnterSecs != value)
                {
                    enterSecs = value;

                    Timer = $"{DigitDoubler(enterMins)} : {DigitDoubler(enterSecs)}";

                };
            }
        }

        private string timer;
        public string Timer { get => timer; set { SetProperty(ref timer, value); } }
        public ICommand StartClick { get; private set; }
        public ICommand PauseClick { get; private set; }

        private string start = "Start";
        public string Start { get => start; set { SetProperty(ref start, value); } }
        private string pause = "Pause";
        public string Pause { get => pause; set { SetProperty(ref pause, value); } }

        public WatchViewModel()
        {

            StartClick = new Command(() =>
            {
                if (!startStatus)
                {
                    startStatus = true;
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        bool timeIsStillReducable = ReduceTime();
                        Start= timeIsStillReducable ? "Restart" : "Start";
                        (PauseClick as Command).ChangeCanExecute();
                        //Timer = $"{DigitDoubler(mins)} : {DigitDoubler(secs)}";
                        return timeIsStillReducable && allowTimer;
                    });
                }
                else if (!allowTimer)
                {
                    allowTimer = !allowTimer;
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        bool timeIsStillReducable = ReduceTime();
                        Start = timeIsStillReducable ? "Restart" : "Start";
                        //Timer = $"{DigitDoubler(mins)} : {DigitDoubler(secs)}";
                        return timeIsStillReducable && allowTimer;
                    });
                }
            });

            PauseClick = new Command(

            execute: () =>
            {
                allowTimer = !allowTimer;
                if (allowTimer) TimerCOntroller();
                Pause = allowTimer ? "Pause" : "Continue";
            },
        canExecute: () =>
        {
            if (startStatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


            );
        }

        //private void Start_Clicked(object sender, EventArgs e)
        //{
        //    mins = int.Parse(minutesEntry.Text ?? 0.ToString());
        //    secs = int.Parse(secondsEntry.Text ?? 0.ToString());
        //    if (!startStatus)
        //    {
        //        startStatus = true;
        //        TimerCOntroller();
        //    }
        //    else if (!allowTimer)
        //    {
        //        allowTimer = !allowTimer;
        //        TimerCOntroller();
        //    }
        //}

        private void TimerCOntroller()
        {
            //if (allowTimer ) return;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                bool timeIsStillReducable = ReduceTime();
                //Timer = $"{DigitDoubler(mins)} : {DigitDoubler(secs)}";
                return timeIsStillReducable && allowTimer;
            });
        }

        private String DigitDoubler(int numb) => numb > 9 ? numb.ToString() : "0" + numb;
        //{
        //    return 
        //}
        //private void PauseClicked(object sender, EventArgs e)
        //{
        //    allowTimer = !allowTimer;
        //    if (allowTimer) TimerCOntroller();
        //    (sender as Button).Text = allowTimer ? "Pause" : "Continue";
        //}
        private bool startStatus = false;
        private bool allowTimer = true;
        //private int secs = 0;
        //private int mins = 0;
        private bool ReduceTime()
        {
        
            if (EnterSecs > 0)
            {
                --EnterSecs;
            }
            else if (EnterSecs == 0 && EnterMins > 0)
            {
                --EnterMins;
                EnterSecs = 59;
            }
            //pause.IsEnabled = !(mins == secs && secs == 0);
            //if (pause.IsEnabled == false) allowTimer = false;
            return EnterMins != 0 || EnterSecs != 0;
        }

        //private void secondsEntry_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        //private void Seconds_Enforcer(object sender, TextChangedEventArgs e)
        //{
        //    Entry entry = sender as Entry;
        //    if (entry.Text is null) return;
        //    entry.Text = entry.Text.Replace(".", String.Empty);
        //    entry.Text = entry.Text.Replace("-", String.Empty);
        //    List<String> unwanteds = new List<String> { 6.ToString(), 7.ToString(), 8.ToString(), 9.ToString() };
        //    if (entry.Text.Length == 2 && unwanteds.IndexOf(entry.Text[0].ToString()) != -1)
        //    {
        //        //entry.Text = entry.Text.Substring(0,1);
        //        entry.Text = entry.Text.Substring(1, 1);
        //    }
        //}
    }
}
