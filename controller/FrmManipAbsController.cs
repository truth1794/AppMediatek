using AppMediatek.dal;
using AppMediatek.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AppMediatek.controller
{
    /// <summary>
    /// Contrôleur de FrmGestion
    /// </summary>
    public class FrmManipAbsController
    {
        /// <summary>
        /// objet d'accès aux opérations possible sur Absence
        /// </summary>
        private readonly AbsenceAcces absenceAcces;
        /// <summary>
        /// objet d'accès aux opérations possible sur Motif
        /// </summary>
        private readonly MotifAcces motifAcces;

        /// <summary>
        /// Récupère les acces aux données
        /// </summary>
        public FrmManipAbsController()
        {
            absenceAcces = new AbsenceAcces();
            motifAcces = new MotifAcces();
        }

        /// <summary>
        /// Récupère et retourne les absences du personnel selectionne
        /// </summary>
        /// <returns>liste des absences</returns>
        public List<Absence> GetAbsences(int idPerso)
        {
            return absenceAcces.GetAbsences(idPerso);
        }

        /// <summary>
        /// Récupère et retourne les motifs
        /// </summary>
        /// <returns>liste des motifs</returns>
        public List<Motif> GetMotifs()
        {
            return motifAcces.GetMotifs();
        }

        /// <summary>
        /// Ajoute une absence
        /// </summary>
        /// <param name="absence">objet absence à ajouter</param>
        public void AddAbsence(Absence absence)
        {
            absenceAcces.AddAbsence(absence);
        }

        /// <summary>
        /// Modification d'une absence
        /// </summary>
        /// <param name="updatedAbsence">object contenant l'absence mise a jour</param>
        /// <param name="absenceToUpdate">object contenant l'absence a mettre a jour</param>
        public void UpdateAbsence(Absence updatedAbsence, Absence absenceToUpdate)
        {
            absenceAcces.UpdateAbsence(updatedAbsence, absenceToUpdate);
        }
    }
}
