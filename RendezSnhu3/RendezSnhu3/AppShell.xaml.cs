using RendezSnhu3.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RendezSnhu3
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("CreateAccountPage" , typeof(CreateAccountPage));
            Routing.RegisterRoute("ShowEventPage", typeof(ShowEventPage));

        }

    }

}
