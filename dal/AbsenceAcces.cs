using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

/// <summary>
/// dal namespace
/// </summary>
namespace AppMediatek.dal
{
    /// <summary>
    /// The <see cref="AppMediatek.dal"/> dal namespace
    /// </summary>

    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
    }
    /// <summary>
    /// Classe gerant les requetes SQL sur la base de donnee lies a la table Absence
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
        /// Récupère et retourne les absences
        /// </summary>
        /// <param name="idPersonnel">id du personnel</param>
        /// <returns>liste des absences</returns>
        public List<Absence> GetAbsences(int idPersonnel)
        {
            List<Absence> absences = new List<Absence>();
            if (access.Manager != null)
            {
                string req = "select a.idpersonnel, a.datedebut, a.idmotif, a.datefin, m.libelle ";
                req += "from absence a, personnel p, motif m ";
                req += "where p.idpersonnel in ";
                req += "(select a.idpersonnel from absence) and ";
                req += "p.idpersonnel = " + idPersonnel.ToString() + " and ";
                req += "m.idmotif = a.idmotif ";
                req += "order by a.datedebut;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        Log.Debug("AbsenceAcces.GetAbsences nb records = {0}", records.Count);
                        foreach (Object[] record in records)
                        {
                            Absence absent = new Absence((int)record[0], (DateTime)record[1], (int)record[2],
                                (DateTime)record[3],(string)record[4]);
                            absences.Add(absent);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("AbsenceAcces.GetAbsences catch req={0} erreur={1}", req, e.Message);
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
                    Log.Error("AbsenceAcces.AddAbsence catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification d'une absence
        /// </summary>
        /// <param name="updatedAbsence">objet absence mis a jour</param>
        /// <param name="absenceToChange">objet absence à modifier</param>
        public void UpdateAbsence(Absence updatedAbsence, Absence absenceToChange)
        {
            if (access.Manager != null)
            {
                string req = "update absence set datedebut = @datedebut, idmotif = @idmotif, datefin = @datefin ";
                req += "where idpersonnel = @idpersonnel ";
                req += "and datedebut = @dateDebutToUpdate;";
                string sqlDateDebut = updatedAbsence.DateDebut.ToString("yyyy-MM-dd 00:00:00");
                string sqlDateFin = updatedAbsence.DateFin.ToString("yyyy-MM-dd 00:00:00");
                string sqlDateDebutToUpdate = absenceToChange.DateDebut.ToString("yyyy-MM-dd HH:mm:ss");
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idpersonnel", updatedAbsence.Idpersonnel },
                    { "@datedebut", sqlDateDebut },
                    { "@dateDebutToUpdate", sqlDateDebutToUpdate },
                    { "@idmotif", updatedAbsence.IdMotif },
                    { "@datefin", sqlDateFin}
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("AbsenceAcces.UpdateAbsence catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }
        /// <summary>
        /// Demande de suppression d'une absence
        /// </summary>
        /// <param name="absence">objet absence à supprimer</param>
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
                    Log.Error("AbsenceAcces.DelAbsence catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
