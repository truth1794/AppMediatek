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
        public Absence(int idPersonnel, string dateDebut, int motif, string dateFin)
        {
            this.Idpersonnel = idPersonnel;
            this.IdMotif = motif;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;

        }

        public int Idpersonnel { get; }
        public int IdMotif { get; set; }
        public string DateDebut { get; set; }
        public string DateFin { get; set; }
    }
}
