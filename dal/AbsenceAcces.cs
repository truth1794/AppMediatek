using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

namespace AppMediatek.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les developpeurs
    /// </summary>
    public class AbsenceAcces
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public AbsenceAcces()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les développeurs
        /// </summary>
        /// <returns>liste des développeurs</returns>
        public List<Absence> GetAbsences(int idPersonnel)
        {
            List<Absence> absences = new List<Absence>();
            if (access.Manager != null)
            {
                //string req = "select p.nom as nom, p.prenom as prenom, a.datedebut, a.datefin, m.libelle as motif, s.nom as service ";
                //req += "from personnel p, absence a, motif m, service s ";
                //req += "where p.idpersonnel in ";
                //req += "(select a.idpersonnel from absence) and p.idservice = s.idservice ";
                //req += "order by nom, prenom;";
                string req = "select a.idpersonnel, a.datedebut, a.idmotif, a.datefin ";
                req += "from absence a ";
                req += "where p.idpersonnel in ";
                req += "(select a.idpersonnel from absence) and ";
                req += "p.idpersonnel = " + idPersonnel.ToString() + " ";
                req += "order by a.datedebut;";
                //req += "order by nom, prenom;";
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

                            //Absence absent = new Absence((int)record[0], (int)record[1], (string)record[2],
                            //    (string)record[3], (string)record[4], (string)record[5]);

                            Absence absent = new Absence((int)record[0], (string)record[1], (int)record[2],
                                (string)record[3]);
                            absences.Add(absent);
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
            return absences;
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

        ///// <summary>
        ///// Demande d'ajout un développeur
        ///// </summary>
        ///// <param name="developpeur">objet developpeur à ajouter</param>
        //public void AddDeveloppeur(Developpeur developpeur)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "insert into developpeur(nom, prenom, tel, mail, pwd, idprofil) ";
        //        req += "values (@nom, @prenom, @tel, @mail, SHA2(@pwd, 256), @idprofil);";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            { "@nom", developpeur.Nom },
        //            { "@prenom", developpeur.Prenom },
        //            { "@tel", developpeur.Tel },
        //            { "@mail", developpeur.Mail },
        //            { "@pwd", developpeur.Nom },
        //            { "@idprofil", developpeur.Profil.Idprofil }
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