using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediatek.Model
{
    // <summary>
    /// Classe métier interne pour mémoriser les informations d'authentification
    /// </summary>
    public class Responsable
    {
        public string Username { get; }
        public string Pwd { get; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        public Responsable(string username, string pwd)
        {
            this.Username = username;
            this.Pwd = pwd;
        }
    }
}
