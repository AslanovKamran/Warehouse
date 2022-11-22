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
    public class Seller : INotifyPropertyChanged
    {
        #region PropertyChanged Realization

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropChanged([CallerMemberName] string prop = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        private string sellerLogin;

        public string SellerLogin
        {
            get { return sellerLogin; }
            set { sellerLogin = value; InvokePropChanged(); }
        }

        private string sellerPassword;

        public string SellerPassword
        {
            get { return sellerPassword; }
            set { sellerPassword = value; InvokePropChanged(); }
        }

        private string sellerName;

        public string SellerName
        {
            get { return sellerName; }
            set { sellerName = value; InvokePropChanged(); }
        }


        private string sellerSurname;

        public string SellerSurname
        {
            get { return sellerSurname; }
            set { sellerSurname = value; InvokePropChanged(); }
        }

        private ObservableCollection<Client> sellerClientList;

        public ObservableCollection<Client> SellerClientList
        {
            get { return sellerClientList; }
            set { sellerClientList = value; InvokePropChanged(); }
        }

        private ObservableCollection<Goods> sellerGoodsList;

        public ObservableCollection<Goods> SellerGoodsList
        {
            get { return sellerGoodsList; }
            set { sellerGoodsList = value; InvokePropChanged(); }
        }

        private ObservableCollection<Order> sellerOrderList;

       

        public ObservableCollection<Order> SellerOrderList
        {
            get { return sellerOrderList; }
            set { sellerOrderList = value; InvokePropChanged(); }
        }


        public Seller()
        {

            SellerLogin = default;
            SellerPassword = default;
            SellerName = default;
            SellerSurname = default;
            SellerClientList = null;
            SellerGoodsList = null;
            SellerOrderList = null;

        }

        public Seller(string login = default, string password = default, string name = default, string surname = default, ObservableCollection<Client> clients = null, ObservableCollection<Goods> goods = null, ObservableCollection<Order> orders = null)
        {

            SellerLogin = login;
            SellerPassword = password;
            SellerName = name;
            SellerSurname = surname;
            SellerClientList = clients;
            SellerGoodsList = goods;
            SellerOrderList = orders;

        }

    }
}
