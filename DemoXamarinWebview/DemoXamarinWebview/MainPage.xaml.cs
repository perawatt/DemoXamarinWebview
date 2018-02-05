using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoXamarinWebview
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            webView.Source = "http://demo-web-end-to-end.azurewebsites.net/";
        }
        void backButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        /// <summary>
        /// Navigates forward
        /// </summary>
        void forwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }
    }
}
