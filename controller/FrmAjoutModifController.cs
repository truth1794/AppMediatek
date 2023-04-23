using AppMediatek.dal;
using AppMediatek.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AppMediatek.controller
{
    /// <summary>
    /// Contrôleur de FrmGestion
    /// </summary>
    public class FrmAjoutModifController
    {
        /// <summary>
        /// objet d'accès aux opérations possibles sur Personnel
        /// </summary>
        private readonly PersonnelAcces personnelAcces;
        /// <summary>
        /// objet d'accès aux opérations possible sur Absence
        /// </summary>
        private readonly AbsenceAcces absenceAcces;
        /// <summary>
        /// objet d'accès aux opérations possible sur Service
        /// </summary>
        private readonly ServiceAcces serviceAcces;
        /// <summary>
        /// objet d'accès aux opérations possible sur Motif
        /// </summary>
        private readonly MotifAcces motifAcces;

        /// <summary>
        /// Récupère les acces aux données
        /// </summary>
        public FrmAjoutModifController()
        {
            personnelAcces = new PersonnelAcces();
            absenceAcces = new AbsenceAcces();
            serviceAcces = new ServiceAcces();
            motifAcces = new MotifAcces();
        }

        /// <summary>
        /// Récupère et retourne les infos du Personnels
        /// </summary>
        /// <returns>liste des développeurs</returns>
        //public List<Personnel> GetInfoPerso()
        //{
        //    return personnelAcces.getInfoPerso();
        //}

        /// <summary>
        /// Récupère et retourne les infos du Personnels
        /// </summary>
        /// <returns>liste des développeurs</returns>
        public List<Service> GetServices()
        {
            return serviceAcces.GetServices();
        }

        /// <summary>
        /// Ajoute un personnel a la base de donnee
        /// </summary>
        /// <param name="personnel">objet personnel à ajouter</param>
        public void AddPersonnel(Personnel personnel)
        {
            personnelAcces.AddPersonnel(personnel);
        }

        /// <summary>
        /// Modifie un personnel de la base de donnee
        /// </summary>
        /// <param name="personnel">objet personnel à modifier</param>
        public void UpdatePersonnel(Personnel personnel)
        {
            personnelAcces.UpdatePersonnel(personnel);
        }

    }
}
