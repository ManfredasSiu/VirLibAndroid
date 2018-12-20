using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualLibrary.presenters;
using VirtualLibrary.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Recommended : ContentPage,IUControlR
	{
		public Recommended ()
		{

            InitializeComponent ();
            new UserControlRecoPresenter(this);
		}

        public string newCell { set => Test.Add(new TextCell() { Text = value }); }
    }
}