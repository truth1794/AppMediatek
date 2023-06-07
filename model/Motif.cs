namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Motif
    /// </summary>
    public class Motif
    {

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idMotif">id du motif</param>
        /// <param name="nom">nom du motif</param>
        public Motif(int idMotif, string nom)
        {
            this.IdMotif = idMotif;
            this.Nom = nom;
        }

        /// <summary>
        /// Entier contenant l'ID du motif
        /// </summary>
        public int IdMotif { get; }
        /// <summary>
        /// chaine contenant le nom du motif
        /// </summary>
        public string Nom { get; set; }
    }
}
