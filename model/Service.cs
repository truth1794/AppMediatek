namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Service
    /// </summary>
    public class Service
    {

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idService">id du service</param>
        /// <param name="nom">nom du service</param>
        public Service(int idService, string nom)
        {
            this.IdService = idService;
            this.Nom = nom;

        }

        /// <summary>
        /// entier contenant l'ID du service
        /// </summary>
        public int IdService { get; }
        /// <summary>
        /// chaine contenant le nom du service
        /// </summary>
        public string Nom { get; set; }
    }
}
