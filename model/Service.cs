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
        /// <param name="idPersonnel"></param>
        /// <param name="nom"></param>
        public Service(int idService, string nom)
        {
            this.IdService = idService;
            this.Nom = nom;

        }

        public int IdService { get; }
        public string Nom { get; set; }
    }
}