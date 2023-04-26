
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
            this.Pwd = Pwd;
        }

        public int Idpersonnel { get; }
        public int Idservice { get; }
        public string Service { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Pwd { get; set; }

    }
}