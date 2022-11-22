using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
using System.Xml.Serialization;

namespace WpfAppWareHouse
{
   
    public partial class SignInWindow : Window
    {
        private ObservableCollection<Seller> mySellers = new();
        public ObservableCollection<Seller> MySellers
        {
            get { return mySellers; }
            set { mySellers = value; }
        }

        private Seller new_seller;

        public Seller NewSeller
        {
            get { return new_seller; }
            set { new_seller = value; }
        }


        public SignInWindow()
        {
            InitializeComponent();
            NewSeller = null;
            using (var fs = new FileStream("MySellers.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                MySellers = xml.Deserialize(fs) as ObservableCollection<Seller>;
            }

        }

       

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SubmitButton_Click(SubmitButton, null);
            }
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
          
            string name = Name.Text;
            string surname = Surname.Text;
            string login = Login.Text;
            string password = Password.Password;

            NewSeller = new Seller(login, password, name, surname, null, null, null);
            MySellers.Add(NewSeller);
            using (var fs = new FileStream("MySellers.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                xml.Serialize(fs, MySellers);
            }
            
            MessageBox.Show($"Submitted");
            this.Hide();
            MainWindow window = new();
            window.ShowDialog();

            this.Close();
          
            
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow window = new();
            window.ShowDialog();
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
