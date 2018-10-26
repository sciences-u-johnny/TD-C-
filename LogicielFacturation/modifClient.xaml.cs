using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogicielFacturation
{
    /// <summary>
    /// Logique d'interaction pour modifClient.xaml
    /// </summary>
    public partial class modifClient : Window
    {
        client monClient;
        public modifClient()
        {
            InitializeComponent();
        }

        public modifClient(client leClient)
        {
            InitializeComponent();
            tb_adresse.Text = leClient.Adresse;
            tb_nom.Text = leClient.Nom;
            tb_prenom.Text = leClient.Prenom;
            tb_telephone.Text = leClient.Telephone;
            tb_id.Text = leClient.Id.ToString();
            monClient = leClient;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nom = tb_nom.Text;
            string prenom = tb_prenom.Text;
            string adresse = tb_adresse.Text;
            string telephone = tb_telephone.Text;
            Guid id = Guid.Parse(tb_id.Text);

            monClient.Nom = nom;
            monClient.Prenom = prenom;
            monClient.Adresse = adresse;
            monClient.Telephone = telephone;

            client.modClient(monClient);
            this.Close();
        }
    }
}
