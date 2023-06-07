using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

namespace AppMediatek.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant le personnel
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
        /// Récupère et retourne le personnel
        /// </summary>
        /// <returns>liste du personnel</returns>
        public List<Personnel> GetLePersonnel()
        {
            List<Personnel> lePersonnel = new List<Personnel>();
            if (access.Manager != null)
            {
                string req = "SELECT p.idpersonnel as idpersonnel,p.idservice as idservice, s.nom as service, p.nom as nom, p.prenom as prenom, p.tel as tel, p.mail as mail ";
                req += "FROM personnel p, service s ";
                req += "WHERE p.idservice = s.idservice ";
                req += "ORDER BY nom, prenom;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        Log.Debug("PersonnelAccess.GetLePersonnel nb records = {0}", records.Count);
                        foreach (Object[] record in records)
                        {
                            Personnel perso = new Personnel((int)record[0], (int)record[1], (string)record[2],
                                (string)record[3], (string)record[4], (string)record[5], (string)record[6]);
                            lePersonnel.Add(perso);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("PersonnelAccess.GetLesDeveloppeurs catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
            return lePersonnel;
        }

        /// <summary>
        /// Demande de suppression d'un personnel
        /// </summary>
        /// <param name="personnel">objet personnel à supprimer</param>
        public void DelPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req0 = "DELETE a ";
                req0 += "FROM absence a ";
                req0 += "WHERE a.idpersonnel = @idpersonnel;";
                string req1 = "DELETE p ";
                req1 += "FROM personnel p ";
                req1 += "WHERE p.idpersonnel = @idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    {"@idpersonnel", personnel.Idpersonnel }
                };
                try
                {
                    access.Manager.ReqUpdate(req0, parameters);
                    access.Manager.ReqUpdate(req1, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("PersonnelAccess.DelDepveloppeur catch req={0} erreur={1}", req0, e.Message);
                    Log.Error("PersonnelAccess.DelDepveloppeur catch req={0} erreur={1}", req1, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Ajouter un personnel
        /// </summary>
        /// <param name="personnel">objet personnel à ajouter</param>
        public void AddPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "INSERT INTO personnel(idservice,nom, prenom, tel, mail) ";
                req += "VALUES (@idservice,@nom, @prenom, @tel, @mail);";
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
                    Log.Error("PersonnelAccess.AddDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification d'un personnel
        /// </summary>
        /// <param name="personnel">objet personnel à modifier</param>
        public void UpdatePersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "UPDATE personnel SET idservice=@idservice, nom = @nom, prenom = @prenom, tel = @tel, mail = @mail ";
                req += "WHERE idpersonnel= @idpersonnel;";
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
                    Log.Error("PersonnelAccess.UpdatePersonnel catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
