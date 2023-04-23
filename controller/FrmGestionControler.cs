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
        public FrmGestionController()
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
        public List<Personnel> GetLePersonnel()
        {
            return personnelAcces.GetLePersonnel();
        }

        /// <summary>
        /// Récupère et retourne les infos des absents
        /// </summary>
        /// <returns>liste des profils</returns>
        public List<Absence> GetAbsences(int idPerso)
        {
            return absenceAcces.GetAbsences(idPerso);
        }
        /// <summary>
        /// supprime un personnel de la base de donnee
        /// </summary>
        /// <param name="personnel">objet personnel à supprimer</param>
        public void DelPersonnel(Personnel personnel)
        {
            personnelAcces.DelPersonnel(personnel);
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur">objet developpeur à supprimer</param>
        //public void DelDeveloppeur(Developpeur developpeur)
        //{
        //    developpeurAccess.DelDepveloppeur(developpeur);
        //}

        ///// <summary>
        ///// Demande de suppression d'un profil
        ///// </summary>
        ///// <param name="profil">objet profil à supprimer</param>
        //public void DelProfil(Profil profil)
        //{
        //    profilAccess.DelProfil(profil);
        //}

        ///// <summary>
        ///// Demande d'ajout d'un profil 
        ///// </summary>
        ///// <param name="profil"></param>
        //public void AddProfil(Profil profil)
        //{
        //    profilAccess.AddProfil(profil);
        //}

        ///// <summary>
        ///// Demande d'ajout d'un développeur
        ///// </summary>
        ///// <param name="developpeur">objet developpeur à ajouter</param>
        //public void AddDeveloppeur(Developpeur developpeur)
        //{
        //    developpeurAccess.AddDeveloppeur(developpeur);
        //}

        ///// <summary>
        ///// Demande de modification d'un développeur
        ///// </summary>
        ///// <param name="developpeur">objet developpeur à modifier</param>
        //public void UpdateDeveloppeur(Developpeur developpeur)
        //{
        //    developpeurAccess.UpdateDeveloppeur(developpeur);
        //}

        ///// <summary>
        ///// Demande de changement de pwd
        ///// </summary>
        ///// <param name="developpeur">objet developpeur avec nouveau pwd</param>
        //public void UpdatePwd(Developpeur developpeur)
        //{
        //    developpeurAccess.UpdatePwd(developpeur);
        //}
    }
}