﻿using Entities;
using System;
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
using UI.ViewModels;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for HistoryFlightsWindow1.xaml
    /// </summary>
    public partial class HistoryFlightsWindow : Window
    {
        HistoryFlightsWindowVM vm = new HistoryFlightsWindowVM();
        public HistoryFlightsWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

    }
}
