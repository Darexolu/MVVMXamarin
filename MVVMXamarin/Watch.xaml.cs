using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Watch : ContentPage
    {
        public Watch()
        {
            InitializeComponent();
            BindingContext = new WatchViewModel();
        }

        private void Seconds_Enforcer(object sender, TextChangedEventArgs e)
        {
           Entry entry = sender as Entry;
           if (entry.Text is null) return;
           entry.Text = entry.Text.Replace(".", String.Empty);
           entry.Text = entry.Text.Replace("-", String.Empty);
           List<String> unwanteds = new List<String> { 6.ToString(), 7.ToString(), 8.ToString(), 9.ToString() };
           if (entry.Text.Length == 2 && unwanteds.IndexOf(entry.Text[0].ToString()) != -1)
           {
              entry.Text = entry.Text.Substring(0,1);
                entry.Text = entry.Text.Substring(1, 1);
            }
        }
    }
}