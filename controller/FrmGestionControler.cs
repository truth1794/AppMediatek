using AppMediatek.dal;
using AppMediatek.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AppMediatek.controller
{
    /// <summary>
    /// Contrôleur de FrmGestion
    /// </summary>
    public class FrmGestionController
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
        /// Récupère les acces aux données
        /// </summary>
        public FrmGestionController()
        {
            personnelAcces = new PersonnelAcces();
            absenceAcces = new AbsenceAcces();
        }

        /// <summary>
        /// Récupère et retourne les infos du Personnels
        /// </summary>
        /// <returns>liste du personnels</returns>
        public List<Personnel> GetLePersonnel()
        {
            return personnelAcces.GetLePersonnel();
        }

        /// <summary>
        /// Récupère et retourne les infos des absents
        /// </summary>
        /// <returns>liste des absences</returns>
        public List<Absence> GetAbsences(int idPerso)
        {
            return absenceAcces.GetAbsences(idPerso);
        }
        /// <summary>
        /// Supprime un personnel de la base de donnee
        /// </summary>
        /// <param name="personnel">objet personnel à supprimer</param>
        public void DelPersonnel(Personnel personnel)
        {
            personnelAcces.DelPersonnel(personnel);
        }
    }
}