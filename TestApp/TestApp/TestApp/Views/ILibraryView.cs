﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    interface ILibraryView
    {
        String codeTXT { get; }
        TableView DataBookss { get; }
    }
}
