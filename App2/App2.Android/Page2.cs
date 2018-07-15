using App2.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App2
{
	public class Page2 : ContentPage
	{
		public Page2 ()
		{
            var logs = LogtoFileHelper.Read();
            var listView = new ListView();

            listView.ItemsSource = logs;
            Content = new StackLayout {
				Children = {
					new Label { Text = "WLogs!" },
                    listView
                }
			};
		}
	}
}