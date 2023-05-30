using System;

namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Absence
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="dateDebut"></param>
        /// <param name="idMotif"></param>
        /// <param name="dateFin"></param>
        /// <param name="motif"></param>
        public Absence(int idPersonnel, DateTime dateDebut, int idMotif, DateTime dateFin, string motif)
        {
            this.Idpersonnel = idPersonnel;
            this.IdMotif = idMotif;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Motif = motif;
        }

        /// <summary>
        /// Entier contenant l'ID du personnel
        /// </summary>
        public int Idpersonnel { get; }
        /// <summary>
        /// Entier contenant l'ID du motif
        /// </summary>
        public int IdMotif { get; set; }
        /// <summary>
        /// DateTime contenant la date de debut de l'absence
        /// </summary>
        public DateTime DateDebut { get; set; }
        /// <summary>
        /// DateTime contenant la date de fin de l'absence
        /// </summary>
        public DateTime DateFin { get; set; }
        /// <summary>
        /// chaine contenant le motif
        /// </summary>
        public string Motif { get; set; }

    }
}
