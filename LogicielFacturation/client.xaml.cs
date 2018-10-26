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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LogicielFacturation
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<client> maListeDeClient;
        client monClient;
        public MainWindow()
        {
            InitializeComponent();
            this.refresh();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        
        }

        private void bt_ajouterclient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nom = tb_nom.Text;
                string prenom = tb_prénom.Text;
                string numero = tb_numero.Text;
                string adresse = tb_adresse.Text;

                client monClient = new client(nom, prenom, numero, adresse);
                client.addClient(monClient);
                MessageBox.Show("Ajout effectué.");
                this.refresh();
            }
            catch
            {
                MessageBox.Show("Impossible d'ajouter ce client");
            }

        }

        private void bt_rechercher_Click(object sender, RoutedEventArgs e)
        {
            string recherche = tb_recherche.Text;
            if(recherche == "")
            {
                this.refresh();
            }
            else
            {
                maListeDeClient = client.rechercheClient(recherche);
                dgvClient.ItemsSource = maListeDeClient;
            }
            

        }

        private void bt_del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgvClient.SelectedIndex != -1)
                {
                    monClient = (client)dgvClient.SelectedItem;
                    client.delClient(monClient);
                    this.refresh();
                }
                else
                {
                    MessageBox.Show("Impossible de supprimer cette ligne.");
                }
            }
            catch
            {
                MessageBox.Show("Impossible de supprimer cette ligne.");
            }

        }

        private void bt_mod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                monClient = (client)dgvClient.SelectedItem;
                modifClient maModif = new modifClient(monClient);
                maModif.Show();
            }
            catch
            {
                MessageBox.Show("Impossible de modifier cette page.");
            }

        }

        private void bt_rechercher_Click_1(object sender, RoutedEventArgs e)
        {
            string recherche = tb_recherche.Text;
            if (recherche == "")
            {
                this.refresh();
            }
            else
            {
                maListeDeClient = client.rechercheClient(recherche);
                dgvClient.ItemsSource = maListeDeClient;
            }
        }

        public void refresh()
        {
            maListeDeClient = client.getClient();
            dgvClient.ItemsSource = maListeDeClient;
        }
    }
}
