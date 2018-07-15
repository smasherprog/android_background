using Android.App.Job;
using App2.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App2
{
    public class MainPage : ContentPage
    {
        Android.Content.Context context;
        public MainPage(Android.Content.Context obj)
        {
            context = obj;
            var b = new Button { Text = "click" };
            b.Clicked += B_Clicked;
            var navtologpage = new Button { Text = "logs" };
            var isrun = new Button { Text = "isrunnning" };
            isrun.Clicked += Isrun_Clicked;
            navtologpage.Clicked += async (sender, e) => { await Navigation.PushAsync(new Page2()); };
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" },
                   b, navtologpage
                }
            };
        }

        private void Isrun_Clicked(object sender, EventArgs e)
        {
            context.isRunning()
        }

        private void B_Clicked(object sender, EventArgs e)
        {
            var jobInfo = context.CreateJobBuilderUsingJobId<DownloadJob>(45)
                      .SetPeriodic(1000 * 60 * 15)//15 minutes is the smallest anways
                      .SetRequiredNetworkType(NetworkType.Any)
                      .SetPersisted(true)
                      .Build();

            if (context.Schedule(jobInfo))
            {
                LogtoFileHelper.Write("Successfully Scheduled Job");
            }
            else
            {
                LogtoFileHelper.Write("Failed Scheduled Job");
            }
        }
    }
}