
namespace AppMediatek.Model
{
    /// <summary>
    /// Classe métier liée à la table Personnel
    /// </summary>
    public class Personnel
    {

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="idPersonnel"></param>
        /// <param name="idService"></param>
        /// <param name="service"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="tel"></param>
        /// <param name="mail"></param>
        public Personnel(int idPersonnel,int idService, string service, string nom, string prenom, string tel, string mail)
        {
            this.Idpersonnel = idPersonnel;
            this.Idservice = idService;
            this.Service = service;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
        }

        /// <summary>
        /// Entier contenant l'ID du personnel
        /// </summary>
        public int Idpersonnel { get; }
        /// <summary>
        /// Entier contenant l'ID du service
        /// </summary>
        public int Idservice { get; }
        /// <summary>
        /// chaine contenant le nom du service
        /// </summary>
        public string Service { get; }
        /// <summary>
        /// chaine contenant le nom du personnel
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// chaine contenant le prenom du personnel
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// chaine contenant le tel du personnel
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// chaine contenant le mail du personnel
        /// </summary>
        public string Mail { get; set; }

    }
}