using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class AddBookPresenter
    {
        AddBook AB;

        public AddBookPresenter(AddBook AB)
        {
            this.AB = AB;
        }

        public void ScanInit()
        {
            // Application.Current.MainPage.Navigation.PushAsync(???);
        }
    }
}
