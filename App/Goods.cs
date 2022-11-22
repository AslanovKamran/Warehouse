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
    public class Goods : INotifyPropertyChanged
    {

        #region PropertyChanged Realization

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropChanged([CallerMemberName] string prop = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        private string goodsName;
        public string GoodsName
        {
            get { return goodsName; }
            set { goodsName = value; InvokePropChanged(); }
        }

        private double goodsPrice;

        public double GoodsPrice
        {
            get { return goodsPrice; }
            set { goodsPrice = value; InvokePropChanged(); }
        }

        private int goodsAmount;

        public int GoodsAmount
        {
            get { return goodsAmount; }
            set { goodsAmount = value; InvokePropChanged(); }
        }

        private string goodsDescription;

        public string GoodsDescription
        {
            get { return goodsDescription; }
            set { goodsDescription = value; InvokePropChanged(); }
        }

        public Goods()
        {
            GoodsName = default;
            GoodsPrice = default;
            GoodsAmount = default;
            GoodsDescription = default;

        }

        public Goods(string name = default, double price = default, int amout = default, string description = default)
        {
            GoodsName = name;
            GoodsPrice = price;
            GoodsAmount = amout;
            GoodsDescription = description;


        }

        public override string ToString()
        {
            return $"{GoodsName}, {GoodsPrice} $ {GoodsAmount} items ";
        }

    }
}
