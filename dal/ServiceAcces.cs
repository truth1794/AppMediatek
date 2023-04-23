using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

namespace AppMediatek.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les developpeurs
    /// </summary>
    public class ServiceAcces
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public ServiceAcces()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les développeurs
        /// </summary>
        /// <returns>liste des développeurs</returns>
        public List<Service> GetServices()
        {
            List<Service> lesServices = new List<Service>();
            if (access.Manager != null)
            {
                string req = "select s.idservice as idservice, s.nom as nom ";
                req += "from service s;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        Log.Debug("PersonnelAccess.GetLePersonnel nb records = {0}", records.Count);
                        foreach (Object[] record in records)
                        {
                            //Log.Debug("PersonnelAccess.GetLePersonnel Profil : id={0} nom={1}", record[5], record[6]);
                            //Log.Debug("PersonnelAccess.GetLePersonnel Developpeur : id={0} nom={1} prenom={2} tel={3} mail={4} ", record[0], record[1], record[2], record[3], record[4]);
                            //Profil profil = new Profil((int)record[5], (string)record[6]);
                            Service service = new Service((int)record[0], (string)record[1]);
                            lesServices.Add(service);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.GetLesDeveloppeurs catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
            return lesServices;
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur">objet developpeur à supprimer</param>
        //public void DelDepveloppeur(Developpeur developpeur)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "delete from developpeur where iddeveloppeur = @iddeveloppeur;";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            {"@iddeveloppeur", developpeur.Iddeveloppeur }
        //        };
        //        try
        //        {
        //            access.Manager.ReqUpdate(req, parameters);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            Log.Error("DeveloppeurAccess.DelDepveloppeur catch req={0} erreur={1}", req, e.Message);
        //            Environment.Exit(0);
        //        }
        //    }
        //}

        /// <summary>
        /// Ajouter un personnel
        /// </summary>
        /// <param name="personnel">objet developpeur à ajouter</param>
        //public void AddDeveloppeur(Personnel personnel)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "insert into personnel(nom, prenom, tel, mail,idservice) ";
        //        req += "values (@nom, @prenom, @tel, @mail,@idservice);";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            { "@nom", personnel.Nom },
        //            { "@prenom", personnel.Prenom },
        //            { "@tel", personnel.Tel },
        //            { "@mail", personnel.Mail },
        //            { "@idservice", personnel.Service }
        //        };
        //        try
        //        {
        //            access.Manager.ReqUpdate(req, parameters);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            Log.Error("DeveloppeurAccess.AddDeveloppeur catch req={0} erreur={1}", req, e.Message);
        //            Environment.Exit(0);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Demande de modification d'un développeur
        ///// </summary>
        ///// <param name="developpeur">objet developpeur à modifier</param>
        //public void UpdateDeveloppeur(Developpeur developpeur)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "update developpeur set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idprofil ";
        //        req += "where iddeveloppeur = @iddeveloppeur;";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            { "@idDeveloppeur", developpeur.Iddeveloppeur },
        //            { "@nom", developpeur.Nom },
        //            { "@prenom", developpeur.Prenom },
        //            { "@tel", developpeur.Tel },
        //            { "@mail", developpeur.Mail },
        //            { "idprofil", developpeur.Profil.Idprofil }
        //        };
        //        try
        //        {
        //            access.Manager.ReqUpdate(req, parameters);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            Log.Error("DeveloppeurAccess.UpdateDeveloppeur catch req={0} erreur={1}", req, e.Message);
        //            Environment.Exit(0);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Demande de modification du pwd
        ///// </summary>
        ///// <param name="developpeur">objet developpeur avec nouveau pwd</param>
        //public void UpdatePwd(Developpeur developpeur)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "update developpeur set pwd = SHA2(@pwd, 256) ";
        //        req += "where iddeveloppeur = @iddeveloppeur;";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            { "@idDeveloppeur", developpeur.Iddeveloppeur },
        //            { "@pwd", developpeur.Pwd }
        //        };
        //        try
        //        {
        //            access.Manager.ReqUpdate(req, parameters);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            Log.Error("DeveloppeurAccess.UpdatePwd catch req={0} erreur={1}", req, e.Message);
        //            Environment.Exit(0);
        //        }
        //    }
        //}

    }
}