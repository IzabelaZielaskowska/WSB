﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zad4
{
    /// <summary>
    /// Logika interakcji dla klasy SzczegolyWindow.xaml
    /// </summary>
    public partial class SzczegolyWindow : Window
    {
        public SzczegolyWindow(string details)
        {
            InitializeComponent();
            detailsTextBlock.Text = details;
        }
    }
}
