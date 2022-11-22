using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace WpfAppWareHouse
{

	public partial class SellerMenuWindow : Window
    {

        #region PropertiesForBinding

        private ObservableCollection<Seller> mySellers = new();
        public ObservableCollection<Seller> MySellers
        {
            get { return mySellers; }
            set { mySellers = value; }
        }


        private ObservableCollection<Client> currentSellerClients = new();
        public ObservableCollection<Client> CurrentSellerClients
        {
            get { return currentSellerClients; }
            set { currentSellerClients = value; }
        }


        private ObservableCollection<Goods> currentSellerGoods = new();
        public ObservableCollection<Goods> CurrentSellerGoods
        {
            get { return currentSellerGoods; }
            set { currentSellerGoods = value; }
        }

        private ObservableCollection<Order> currentSellerOrders= new();
        public ObservableCollection<Order> CurrentSellerOrders
        {
            get { return currentSellerOrders; }
            set { currentSellerOrders = value; }
        }

        private Seller currentSeller;
        public Seller CurrentSeller
        {
            get { return currentSeller; }
            set { currentSeller = value; }
        }

        private string currentSellerName;

        public string CurrentSellerName
        {
            get { return currentSellerName; }
            set { currentSellerName = value; }
        }


        #endregion

        //Index of the seller, that have logged in
        public int index = ClassForIndex.index; 
        public SellerMenuWindow()
        {
            InitializeComponent();
            
            DataContext = this;
            MakeAnOrderAmountUpDown.Minimum = 1;

            //Getting list of sellers from MySelles.xml document
            using (var fs = new FileStream("MySellers.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                MySellers = xml.Deserialize(fs) as ObservableCollection<Seller>;
            }


            //Initiazling Clients, Goods and Orders of the current seller
            
            #region InitializingStartData
           
            CurrentSellerClients = MySellers[index].SellerClientList;
            CurrentSellerGoods = MySellers[index].SellerGoodsList;
            CurrentSellerOrders = MySellers[index].SellerOrderList;
            
            CurrentSellerName = "Welcome " + MySellers[index].SellerName + " " + MySellers[index].SellerSurname;
            #endregion


        }



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        //Closes the current window
        private void PowerOffButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to exit", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
            else { return; }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            //Adding new client to the current Seller's ClientsList
            string clientName = ClientName.Text;
            string clientSurname = ClientSurname.Text;
            string clientEmail = ClientEmail.Text;
            string clientPhone = ClientPhone.Text;
            string clientAdress = ClientAdress.Text;
            CurrentSellerClients.Add(new Client(clientName, clientSurname, clientEmail, clientPhone, clientAdress));
        


            //Refreshing the MySellers.xml Document. So I can see just added data and binding will work propperly
            using (var fs = new FileStream("MySellers.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                xml.Serialize(fs, MySellers);
            }


            //Clearing TextBoxes
            ClientName.Clear();
            ClientSurname.Clear();
            ClientEmail.Clear();
            ClientPhone.Clear();
            ClientAdress.Clear();

        }

        private void AddGoodsButton_Click(object sender, RoutedEventArgs e)
        {
            string gname = GoodsName.Text;
            double gprice = default;
            int gamount = default;
            string gdescr = GoodsDescription.Text;
            bool isOk = true;
            
            try
            {
                gprice = Convert.ToDouble(GoodsPrice.Text);
            }
            catch (Exception)
            {
                isOk = false;
                MessageBox.Show("Input proper price  format");
            }
            try
            {
                gamount = Convert.ToInt32(GoodsAmount.Text);
            }
            catch (Exception)
            {
                isOk = false;
                MessageBox.Show("Input proper amount format");
            }


            if (isOk) 
            {

                CurrentSellerGoods.Add(new Goods(gname, gprice, gamount, gdescr));

                using (var fs = new FileStream("MySellers.xml", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                    xml.Serialize(fs, MySellers);
                }

            }


            GoodsName.Clear();
            GoodsPrice.Clear();
            GoodsAmount.Clear();
            GoodsDescription.Clear();


        }

        private void MakeAnOrder_Click(object sender, RoutedEventArgs e)
        {
            int index_of_client = MakeAnOrderClientsList.SelectedIndex;
            int index_of_goods = MakeAnOrderGoodsList.SelectedIndex;
            DateTime? date = OrderDate.SelectedDate;
            int selected_amount = default;
            selected_amount = Convert.ToInt32(MakeAnOrderAmountUpDown.Value);
            int current_amount = default;
            bool isOk = true;
            Goods goods_for_order = null;
            Client client_for_order = null;

            if (index_of_client == -1 || index_of_goods == -1)
            {
                MessageBox.Show($"Pick one client and one goods from the list to make an order");
                isOk = false;
            }

            if (date == null)
            {
                MessageBox.Show($"Date is not picked");
                isOk = false;
            }

            else
            {

               goods_for_order = MakeAnOrderGoodsList.Items[index_of_goods] as Goods;

               client_for_order = MakeAnOrderClientsList.Items[index_of_client] as Client;
               current_amount = goods_for_order.GoodsAmount;

                if (selected_amount > current_amount)
                {
                    isOk = false;
                    MessageBox.Show($"There is not enough goods for your order");
                    MakeAnOrderAmountUpDown.Value = 1;

                }

                if (isOk)
                {
                    CurrentSellerGoods[index_of_goods].GoodsAmount -= selected_amount;
                    CurrentSellerOrders.Add(new Order(client_for_order, goods_for_order, selected_amount, Convert.ToDateTime(date)));

                    using (var fs = new FileStream("MySellers.xml", FileMode.Open))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(ObservableCollection<Seller>));
                        xml.Serialize(fs, MySellers);
                    }
                    MessageBox.Show("Success", "Successfull order", MessageBoxButton.OK);

                }
            } 
            

            
           


        }
    }
}
