using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class classWorkMVVMmultiply : ContentPage
    {
        //public ClassWorkMultiplyMVVMViewModel viewmodel;

        public classWorkMVVMmultiply()
        {

            InitializeComponent();
            //viewmodel = new ClassWorkMultiplyMVVMViewModel();
            //this.BindingContext = viewmodel;
        }
    }
}