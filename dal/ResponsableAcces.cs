using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

namespace AppMediatek.dal
{
    public class ResponsableAcces
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public ResponsableAcces()
        {
            access = Access.GetInstance();
        }
        /// <summary>
        /// Controle si l'utillisateur a le droit de se connecter (nom, prénom, pwd et profil "admin")
        /// </summary>
        /// <param name="responsable"></param>
        /// <returns>vrai si l'utilisateur a le profil "admin"</returns>
        public Boolean ControleAuthentification(Responsable responsable)
        {
            if (access.Manager != null)
            {
                string req = "select * from responsable r ";
                req += "where r.login=@login and r.pwd=SHA2(@pwd, 256);";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@login", responsable.Login },
                    { "@pwd", responsable.Pwd }
                };

                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        return (records.Count > 0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("PersonnelAcces.ControleAuthentification catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
        }
    }
}
