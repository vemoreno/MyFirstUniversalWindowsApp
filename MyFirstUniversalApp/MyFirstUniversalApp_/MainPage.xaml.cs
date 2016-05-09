using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using MyFirstUniversalApp_.ServiceReference1;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyFirstUniversalApp_
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ServiceDataClient ServiceWCF = new ServiceDataClient();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendData();
        }

        private async void SendData()
        {
            await ServiceWCF.AddData_Async(txtName.Text.Trim(),
                                        txtMail.Text.Trim(),
                                        Convert.ToInt32(txtAge.Text.Trim()));

            MessageDialog Message = new MessageDialog("Data Sent", "Hello UWP in Windows 10");
            await Message.ShowAsync();
        }

        private void btnViewData_Click(object sender, RoutedEventArgs e)
        {
            ViewData();
        }

        private async void ViewData()
        {
            foreach (SomeData Data in await ServiceWCF.GetData_Async())
                txtData.Text += Data.Name + ", " + Data.Mail + ", " + Data.Age + '\n';
        }
    }
}
