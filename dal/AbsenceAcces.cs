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
        /// Ajouter une absence
        /// </summary>
        /// <param name="absence">objet absence à ajouter</param>
        public void AddAbsence(Absence absence)
        {
            if (access.Manager != null)
            {

                //string req = "SET FOREIGN_KEY_CHECKS=0; ";
                //req += "insert into absence(idpersonnel,datedebut, idmotif, datefin) ";
                //req += "values (@idpersonnel,@datedebut, @idmotif, @datefin); ";
                //req += "SET FOREIGN_KEY_CHECKS = 1;";
                string req = "insert into absence(idpersonnel,datedebut, idmotif, datefin) ";
                req += "values (@idpersonnel,@datedebut, @idmotif, @datefin); ";
                string sqlFormatDateDebut = absence.DateDebut.ToString("yyyy-MM-dd 00:00:00.fff");
                string sqlFormatDateFin = absence.DateFin.ToString("yyyy-MM-dd 00:00:00.fff");
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idpersonnel", absence.Idpersonnel },
                    { "@datedebut", sqlFormatDateDebut },
                    { "@idmotif", absence.IdMotif },
                    { "@datefin", sqlFormatDateFin }
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
        /// <param name="absence">objet developpeur à modifier</param>
        public void UpdateAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req = "update absence set datedebut=@datedebut, idmotif = @idmotif, datefin = @datefin ";
                req += "where idpersonnel= @idpersonnel;";
                string sqlFormatDateDebut = absence.DateDebut.ToString("yyyy-MM-dd 00:00:00.fff");
                string sqlFormatDateFin = absence.DateFin.ToString("yyyy-MM-dd 00:00:00.fff");
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idpersonnel", absence.Idpersonnel },
                    { "@datedebut", sqlFormatDateDebut },
                    { "@idmotif", absence.IdMotif },
                    { "@datefin", sqlFormatDateFin}
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
        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="absence">objet developpeur à supprimer</param>
        public void DelAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req = "delete from absence  ";
                req += "where idpersonnel = @idpersonnel ";
                req += "and datedebut = @datedebut ";
                req += "and datefin = @datefin;";
                string sqlFormatDateDebut = absence.DateDebut.ToString("yyyy-MM-dd HH:mm:ss");
                string sqlFormatDateFin = absence.DateFin.ToString("yyyy-MM-dd HH:mm:ss");
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    {"@idpersonnel", absence.Idpersonnel },
                    {"@datedebut", sqlFormatDateDebut },
                    {"@datefin", sqlFormatDateFin }
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
    }
}