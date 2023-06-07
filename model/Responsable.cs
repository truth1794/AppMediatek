using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Responsable
    /// </summary>
    public class Responsable
    {
        

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="login">login du responsable</param>
        /// <param name="pwd">mot de passe du responsable</param>
        public Responsable(string login, string pwd)
        {
            this.Login = login;
            this.Pwd = pwd;
        }

        /// <summary>
        /// chaine contenant le login
        /// </summary>
        public string Login { get; }
        /// <summary>
        /// chaine contenant le mot de passe (pwd)
        /// </summary>
        public string Pwd { get; }
    }
}
