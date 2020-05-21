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
using System.IO;
using SQLite;
using System.Data.Objects;

namespace borriello.sasha._5G.AziendaWPF
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            //var databasePath = Path.Combine(
            //    Environment.CurrentDirectory,
            //    "Azienda.db"
            //);

            //var db = new SQLiteConnection(databasePath);
            //db.CreateTable<Dipendente>();

            ////Dipendente d = new Dipendente { Nome = "Pippo", Cognome = "Franco", Indirizzo = "Via Sarlack 234" };
            ////db.Insert(d);

            //var risultato = db.Query<Dipendente>("select * from Dipendente");
            
            ////foreach (var item in risultato)
            ////{
            ////    Console.WriteLine(item);
            ////}

        }

        private void Btn_Aggiorna_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "Azienda.db"
            );

            var db = new SQLiteConnection(databasePath);
            db.CreateTable<Dipendente>();

            var risultato = db.Query<Dipendente>("SELECT * FROM Dipendente");

            DG_DB.ItemsSource = risultato;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "Azienda.db"
            );

            var db = new SQLiteConnection(databasePath);
            db.CreateTable<Dipendente>();

            var risultato = db.Query<Dipendente>("SELECT * FROM Dipendente");

            DG_DB.ItemsSource = risultato;

        }

        private void Btn_Aggiungi_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "Azienda.db"
            );

            var db = new SQLiteConnection(databasePath);
            db.CreateTable<Dipendente>();

            string NomeText = TxT_Nome.Text;
            string CognomeText = TxT_Cognome.Text;
            string ViaText = TxT_Via.Text;

            if(NomeText == "" || CognomeText == "" || ViaText == "")
            {

                MessageBox.Show("Inserire i valori in tutti i campi");

            }
            else
            {

                Dipendente d = new Dipendente { Nome = NomeText, Cognome = CognomeText, Indirizzo = ViaText };
                db.Insert(d);

            }

            TxT_Nome.Text = "";
            TxT_Cognome.Text = "";
            TxT_Via.Text = "";

            var risultato = db.Query<Dipendente>("SELECT * FROM Dipendente");

            DG_DB.ItemsSource = risultato;

        }

        private void Btn_Cancella_Click(object sender, RoutedEventArgs e)
        {

            var databasePath = Path.Combine(
                Environment.CurrentDirectory,
                "Azienda.db"
            );

            var db = new SQLiteConnection(databasePath);
            db.CreateTable<Dipendente>();

            db.Query<Dipendente>("DELETE FROM Dipendente WHERE ID = (SELECT MAX(id) FROM Dipendente)");

            var risultato = db.Query<Dipendente>("SELECT * FROM Dipendente");

            DG_DB.ItemsSource = risultato;

        }
    }

    public class Dipendente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }

        public override string ToString()
        {
            return $"{Id} {Nome} {Cognome} {Indirizzo} {GetHashCode()}";
        }
    }
}
