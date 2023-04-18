using Microsoft.Win32;
using Station.DB;
using Station.Savers;
using System.Windows;

namespace Station
{

    public partial class MainWindow : Window
    {
        private Document currnDocument;
        private ISaveFile saver;
        public MainWindow(ISaveFile s) {
            InitializeComponent();
            ///Сохранятор из DI
            saver = s;

        }

        private void CreateNewDocument(object sender, RoutedEventArgs e) {
            currnDocument = new Document();
             StationControl.SetStation(currnDocument.Station);

        }

        private void SaveAsButton_Click(object sender, RoutedEventArgs e) {

             
            SaveFileDialog dis = new SaveFileDialog();
            if (dis.ShowDialog() == true) {
                string path = dis.FileName;
                saver.SaveToDir(currnDocument, path);
            }


        }

        private void OpenDoc_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true) {
                string path = dialog.FileName;
                Document doc = saver.OpenFromFile(path);
                currnDocument = doc;
                StationControl.SetStation(currnDocument.Station);
            }
        }
    }
}
