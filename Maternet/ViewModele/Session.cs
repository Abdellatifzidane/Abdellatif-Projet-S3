using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Maternet.View;

namespace Maternet.Modele
{
    class Session
    {
        public static UserTypes CurrentUserType = UserTypes.NULL;

        public static string CurrentUserId
        {
            get { return Properties.Settings.Default.CurrentUserId; }
            set
            {
                Properties.Settings.Default.CurrentUserId = value;
                Properties.Settings.Default.Save();
            }
        }

        public static bool IsLoggedIn
        {
            get { return Properties.Settings.Default.IsLoggedIn; }
            set
            {
                Properties.Settings.Default.IsLoggedIn = value;
                Properties.Settings.Default.Save();
            }
        }

        public static void Login(string userId, UserTypes userType )
        {
            CurrentUserId = userId;
            CurrentUserType = userType;
            IsLoggedIn = true;

            Home_page home_Page = new Home_page();
            home_Page.ShowDialog(); 
        }


        // ce deuxième constructeur est utiliser en cas l'utilisateur est déja connecté à son compte
        public static void Login()
        {
            Home_page home_Page = new Home_page();
            home_Page.ShowDialog();
            
        }

        public static void Logout()
        {
            IsLoggedIn = false;
            CurrentUserId = "";
        }
    }
}
