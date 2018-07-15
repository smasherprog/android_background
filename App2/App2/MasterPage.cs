using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App2
{
	public class MainPage : ContentPage
	{
		public MainPage()
        {
            var b = new Button { Text = "click" };
            b.Clicked += B_Clicked;
            Content = new StackLayout {
				Children = {
					new Label { Text = "Welcome to Xamarin.Forms!" },
                   
				}
			};
		}

        private void B_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}