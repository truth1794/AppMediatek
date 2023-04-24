namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Developpeur
    /// </summary>
    public class Motif
    {

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idMotif"></param>
        /// <param name="nom"></param>
        public Motif(int idMotif, string nom)
        {
            this.IdMotif = idMotif;
            this.Nom = nom;
        }

        public int IdMotif { get; }
        public string Nom { get; set; }
    }
}