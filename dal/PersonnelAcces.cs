﻿using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

namespace AppMediatek.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les developpeurs
    /// </summary>
    public class PersonnelAcces
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public PersonnelAcces()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les développeurs
        /// </summary>
        /// <returns>liste des développeurs</returns>
        public List<Personnel> GetLePersonnel()
        {
            List<Personnel> lePersonnel = new List<Personnel>();
            if (access.Manager != null)
            {
                string req = "select p.idpersonnel as idpersonnel,p.idservice as idservice, s.nom as service, p.nom as nom, p.prenom as prenom, p.tel as tel, p.mail as mail ";
                req += "from personnel p, service s ";
                req += "where p.idservice = s.idservice ";
                req += "order by nom, prenom;";
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
                            Personnel perso = new Personnel((int)record[0], (int)record[1], (string)record[2],
                                (string)record[3], (string)record[4], (string)record[5], (string)record[6]);
                            lePersonnel.Add(perso);
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
            return lePersonnel;
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="personnel">objet developpeur à supprimer</param>
        public void DelPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "delete from personnel where idpersonnel = @idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    {"@idpersonnel", personnel.Idpersonnel }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.DelDepveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Ajouter un personnel
        /// </summary>
        /// <param name="personnel">objet developpeur à ajouter</param>
        public void AddPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "insert into personnel(idservice,nom, prenom, tel, mail) ";
                req += "values (@idservice,@nom, @prenom, @tel, @mail);";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idservice", personnel.Idservice },
                    { "@nom", personnel.Nom },
                    { "@prenom", personnel.Prenom },
                    { "@tel", personnel.Tel },
                    { "@mail", personnel.Mail }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.AddDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="personnel">objet developpeur à modifier</param>
        public void UpdatePersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "update personnel set idservice=@idservice, nom = @nom, prenom = @prenom, tel = @tel, mail = @mail ";
                req += "where idpersonnel= @idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idpersonnel", personnel.Idpersonnel },
                    { "@idservice", personnel.Idservice },
                    { "@nom", personnel.Nom },
                    { "@prenom", personnel.Prenom },
                    { "@tel", personnel.Tel },
                    { "@mail", personnel.Mail }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.UpdateDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

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