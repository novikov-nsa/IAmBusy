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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IAmBusy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //public WorkWithFile configFile { get; set; }
        public DataAccess dataAccess;
        public string s;
        
        public MainPage()
        {
            this.InitializeComponent();

            /*configFile = new WorkWithFile();
            configFile.CheckFileIsExist();
            //string fname = configFile.filename;
            configFile.getTextFromFile(configFile.messageText);
            this.TextBoxMessagetext.Text = configFile.messageTextFromFile;*/

            dataAccess = new DataAccess();
            dataAccess.ValidateFile();
            dataAccess.ReadFromFile();

        }

        

        private void buttonReadFromFile_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.ReadFromFile();
            s = dataAccess.messageText;
            //s = DataAccess.mText;
            if (s != null)
            {
                TextBoxMessagetext.Text = s;
            }
        }

        private void buttonStoreToFile_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.StoreToFile(TextBoxMessagetext.Text);
        }
    }
}
