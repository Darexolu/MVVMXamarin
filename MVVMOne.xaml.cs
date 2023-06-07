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
    public partial class MVVMOne : ContentPage
    {
        public MVVM_ViewModel viewModel;
        public MVVMOne()
        
        {   
            InitializeComponent();
            viewModel = new MVVM_ViewModel { Name = "John" };
            this.BindingContext = viewModel;
        }
    }
}
