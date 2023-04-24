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
                string req = "select a.idpersonnel, a.datedebut, a.idmotif, a.datefin, m.libelle ";
                req += "from absence a, personnel p, motif m ";
                req += "where p.idpersonnel in ";
                req += "(select a.idpersonnel from absence) and ";
                req += "p.idpersonnel = " + idPersonnel.ToString() + " and ";
                req += "m.idmotif = a.idmotif ";
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

                            Absence absent = new Absence((int)record[0], (DateTime)record[1], (int)record[2],
                                (DateTime)record[3],(string)record[4]);
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
        /// Ajouter un personnel
        /// </summary>
        /// <param name="personnel">objet developpeur à ajouter</param>
        //public void AddAbsence(Absence absence)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "insert into personnel(idservice,nom, prenom, tel, mail) ";
        //        req += "values (@idservice,@nom, @prenom, @tel, @mail);";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            { "@idservice", personnel.Idservice },
        //            { "@nom", personnel.Nom },
        //            { "@prenom", personnel.Prenom },
        //            { "@tel", personnel.Tel },
        //            { "@mail", personnel.Mail }
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

        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="personnel">objet developpeur à modifier</param>
        //public void UpdateAbsence(Personnel personnel)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "update personnel set idservice=@idservice, nom = @nom, prenom = @prenom, tel = @tel, mail = @mail ";
        //        req += "where idpersonnel= @idpersonnel;";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            { "@idpersonnel", personnel.Idpersonnel },
        //            { "@idservice", personnel.Idservice },
        //            { "@nom", personnel.Nom },
        //            { "@prenom", personnel.Prenom },
        //            { "@tel", personnel.Tel },
        //            { "@mail", personnel.Mail }
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
        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="personnel">objet developpeur à supprimer</param>
        //public void DelPersonnel(Personnel personnel)
        //{
        //    if (access.Manager != null)
        //    {
        //        string req = "delete from personnel where idpersonnel = @idpersonnel;";
        //        Dictionary<string, object> parameters = new Dictionary<string, object> {
        //            {"@idpersonnel", personnel.Idpersonnel }
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
    }
}