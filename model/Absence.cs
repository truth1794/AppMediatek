using System;

namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Developpeur
    /// </summary>
    public class Absence
    {
        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="motif"></param>
        /// <param name="dateDebut"></param>
        /// <param name="dateFin"></param>
        /// <param name="motif"></param>
        public Absence(int idPersonnel, DateTime dateDebut, int idMotif, DateTime dateFin, string motif)
        {
            this.Idpersonnel = idPersonnel;
            this.IdMotif = idMotif;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.Motif = motif;

            //DateTime myDateTime = DateTime.Now;
            //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }

        public int Idpersonnel { get; }
        public int IdMotif { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Motif { get; set; }

    }
}
