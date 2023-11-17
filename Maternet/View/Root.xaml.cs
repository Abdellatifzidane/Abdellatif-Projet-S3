using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
using Maternet.Modele;

namespace Maternet.View
{
    /// <summary>
    /// Logique d'interaction pour login.xaml
    /// </summary>
    public partial class Root : Window
    {

        public Root()
        {
            CheckSession();
        }



        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            // j'ai mis les couleurs just pour voir quelle utilisateur est sélectionné .. 
            AdminSelector.Background = new SolidColorBrush(Colors.Green);
            TeacherSelector.Background = new SolidColorBrush(Colors.Gray);

            // la classe Session : je l'ai mis ses attributs static pour qu'ils soient  partager entre tout les classes 
            // de l'application, la ou ont va stocké le id et le Type de l'utilisateur qui a été connecté parce que ont va 
            // les utiliser souvent.
            Session.CurrentUserType = UserTypes.ADMIN;

            // pour les types des utlisateur j'ai creé un enum ( dossier modele )
        }

        private void Teacher_Click_1(object sender, RoutedEventArgs e)
        {
           TeacherSelector.Background = new SolidColorBrush(Colors.Green);
            AdminSelector.Background = new SolidColorBrush(Colors.Gray);
            Session.CurrentUserType = UserTypes.TEACHER;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

            string errorMessage = "";

            if(string.IsNullOrEmpty(password.Text)) {
                errorMessage += "le mot de passe est obligatoire "  + Environment.NewLine;
            }
            if (string.IsNullOrEmpty(email.Text))
            {
                errorMessage += "l'email est obligatoire " + Environment.NewLine;
            }
            if (Session.CurrentUserType == UserTypes.NULL)
            {
                errorMessage += " le choix de type d'utilisateur est obligatoire" + Environment.NewLine;
            }
            if (errorMessage != "")
            {
                MessageBox.Show(errorMessage,"Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }

            // TODO 
            // validation des entrés de l'utilisateur coté base de données 

            // ici j'ai juste donner un example de id = 99
            //... 

            // si tout est validé : 
            if(errorMessage == "")
            {
                Session.Login("9455", Session.CurrentUserType);
                // Close the login window
                this.Close();
            }
        }


        private void CheckSession()
        {
            if(Session.IsLoggedIn == true)
            {
                Session.Login();
                Close();    
            }
            else
            {
                InitializeComponent();
            }
        }
    }
}
