using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoreInfo : ContentPage, IMoreInfoView
    {
        MoreInfoPresenter MIP;
        public TableView Info_book => Info_books;
        public MoreInfo()
        {
            InitializeComponent();
            MIP = new MoreInfoPresenter(this);

        }

       
        private void Cancel_Button(object sender, EventArgs e)
        {
            MIP.InitCancel();
        }
    }
}