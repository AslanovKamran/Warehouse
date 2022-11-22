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
    public class Order : INotifyPropertyChanged
    {
        #region PropertyChanged Realization

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropChanged([CallerMemberName] string prop = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        private Client orderingClient;

        public Client OrderingClient
        {
            get { return orderingClient; }
            set { orderingClient = value; InvokePropChanged(); }
        }

        private Goods goodsToOrder;

        public Goods GoodsToOrder
        {
            get { return goodsToOrder; }
            set { goodsToOrder = value; InvokePropChanged(); }
        }

        private int orderAmount;

        public int OrderAmount
        {
            get { return orderAmount; }
            set { orderAmount = value; InvokePropChanged(); }
        }
       
        private DateTime orderTime;
        public DateTime OrderTime
        {
            get { return orderTime; }
            set { orderTime = value; InvokePropChanged(); }
        }

        public Order()
        {
            OrderingClient = null;
            GoodsToOrder = null;
            OrderAmount = default;
            OrderTime = DateTime.Now;

        }

        public Order(Client client = null, Goods goods = null, int amount = default, DateTime date = default)
        {
            OrderingClient = client;
            GoodsToOrder = goods;
            OrderAmount = amount;
            OrderTime = date;

        }

        

    }

}
