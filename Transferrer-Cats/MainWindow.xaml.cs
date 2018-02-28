using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Util.Store;
using Transferrer_Cats.Models;

namespace Transferrer_Cats
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Scopes for sheets
        private static string[] Scopes = {SheetsService.Scope.Spreadsheets};

        //Application Name
        private static string ApplicationName = "Transferrer-Cats";

        //Service
        private static SheetsService service;


        public MainWindow()
        {
            InitializeComponent();

            //Save cred location
            string credPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            credPath = System.IO.Path.Combine(credPath, ".credentials/transferrer/cred.json");
            UserCredential cred = null;

            if (File.Exists(credPath))
            {
                //Do nothing, Sheets api stores info internally.
            }
            else
            {

                MessageBox.Show("You'll need to connect me to Google! Hit Ok to Continue...", "Authorization",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                //Load client secrets
                using (var stream = File.OpenRead(Paths.LocalSecret))
                {


                    cred = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None
                        , new FileDataStore(credPath, true)
                    ).Result;
                }
               
            }


            //Init Service
            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = cred,
                ApplicationName = ApplicationName
            });



            //Buffer
            var sb = new StringBuilder();
            //Get test spreadsheet
            var test = service.Spreadsheets.Values.Get(ID.Test, "A1:Z1").Execute();

            foreach (var val in test.Values)
            {
                foreach (var cell in val)
                {
                    sb.Append(cell + " ");

                }
                sb.AppendLine("");
            }

            MessageBox.Show("Debug TestResults:\n" + sb.ToString());







        }





        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
