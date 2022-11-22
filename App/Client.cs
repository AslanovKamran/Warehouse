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
    
    public class Client : INotifyPropertyChanged

    {
        #region PropertyChanged Realization

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropChanged([CallerMemberName] string prop = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        private string clientName;

        public string ClientName
        {
            get { return clientName; }
            set { clientName = value; InvokePropChanged(); }
        }

        private string clientSurname;

        public string ClientSurname
        {
            get { return clientSurname; }
            set { clientSurname = value; InvokePropChanged(); }
        }

        private string clientEmail;

        public string ClientEmail
        {
            get { return clientEmail; }
            set { clientEmail = value; InvokePropChanged(); }
        }

        private string clientPhone;

        public string ClientPhone
        {
            get { return clientPhone; }
            set { clientPhone = value; InvokePropChanged(); }
        }

        private string clientAdress;


        public string ClientAdress
        {
            get { return clientAdress; }
            set { clientAdress = value; InvokePropChanged(); }
        }

        public Client()
        {
            ClientName = default;
            ClientSurname = default;
            ClientEmail = default;
            ClientPhone = default;
            ClientAdress = default;
        }

        public Client(string name = default, string surname = default, string email = default, string phone = default, string adress = default)
        {
            ClientName = name;
            ClientSurname = surname;
            ClientEmail = email;
            ClientPhone = phone;
            ClientAdress = adress;

        }

        public override string ToString()
        {
            return $"{ClientName} {ClientSurname}";
        }



    }
}
