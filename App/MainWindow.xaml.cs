using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace WpfAppWareHouse
{

	public partial class MainWindow : Window
    {
        private ObservableCollection<Seller> mySellers = new();
        public ObservableCollection<Seller> MySellers
        {
            get { return mySellers; }
            set { mySellers = value; }
        }

        private int index_of_seller = 0;
        public int Index_of_seller
        {
            get { return index_of_seller; }
            set { index_of_seller = value; }
        }



        public MainWindow()
        {
            InitializeComponent();
            using (var fs = new FileStream("MySellers.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                MySellers = xml.Deserialize(fs) as ObservableCollection<Seller>;
            }

        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {

            
            bool isCorrect = false; 

         

            string login        =   LoginTextBox.Text;
            string password     =   PasswordTextBox.Password.ToString();
            string password_2   =   RepeatPasswordTextBox.Password.ToString();

            if (password != password_2)
            {
                MessageBox.Show("Passwords don't match");
                LoginTextBox.Clear();
                PasswordTextBox.Clear();
                RepeatPasswordTextBox.Clear();

            }

            else if (password == password_2)
            {
                for (int i = 0; i < MySellers.Count; i++)
                {
                    if (MySellers[i].SellerLogin == login)
                    {
                        if(MySellers[i].SellerPassword != password)
                        {
                            isCorrect = false;
                        }
                        else if (MySellers[i].SellerPassword == password)
                        {
                            Index_of_seller = i;
                            
                            isCorrect = true;
                            break;
                        }
                       
                    }

                    else 
                    {
                        isCorrect = false;

                    }
                }
            }

            if (isCorrect)
            {
               
               
                ClassForIndex.index = Index_of_seller;
                this.Hide();
                SellerMenuWindow sellerMenuWindow = new();
                sellerMenuWindow.ShowDialog();

                LoginTextBox.Clear();
                PasswordTextBox.Clear();
                RepeatPasswordTextBox.Clear();
            
                this.Close();
            }

            else 
            {
                MessageBox.Show("Wrong data");
                LoginTextBox.Clear();
                PasswordTextBox.Clear();
                RepeatPasswordTextBox.Clear();
            }
            

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                LogInButton_Click(LogInButton, null);
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();

            SignInWindow signInWindow = new();
            signInWindow.ShowDialog();
            

            //using (var fs = new FileStream("MySellers.xml", FileMode.Open))
            //{
            //    XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
            //    xml.Serialize(fs, MySellers);
            //}

            this.Close();
        }
    }
}
