using AppMediatek.dal;
using AppMediatek.Model;
using System.Collections.Generic;

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
        /// objet d'accès aux opérations possible sur Service
        /// </summary>
        private readonly ServiceAcces serviceAcces;


        /// <summary>
        /// Récupère les acces aux données
        /// </summary>
        public FrmAjoutModifController()
        {
            personnelAcces = new PersonnelAcces();
            serviceAcces = new ServiceAcces();
        }


        /// <summary>
        /// Récupère et retourne les differents services
        /// </summary>
        /// <returns>liste des services</returns>
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
