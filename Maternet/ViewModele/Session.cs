using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maternet.View;

namespace Maternet.Modele
{
    class Session
    {
        public static string CurrentUserId { get; set; }
        public static UserTypes CurrentUserType { get; set; }

        public static void Login(string userId, UserTypes userType )
        {
            CurrentUserId = userId;
            CurrentUserType = userType;

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
            CurrentUserType = UserTypes.NULL;
        }
    }
}
