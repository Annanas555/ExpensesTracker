using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ExpenditureTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Data.TrackerContext Context
        { get; } = new Data.TrackerContext();
        public static Models.User CurrentUser = null;
    }
}
