using AppMediatek.dal;
using AppMediatek.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AppMediatek.controller
{
    /// <summary>
    /// The <see cref="AppMediatek.controller"/> controller namespace
    /// </summary>

    [System.Runtime.CompilerServices.CompilerGenerated]
    class NamespaceDoc
    {
    }
    /// <summary>
    /// Contrôleur de FrmGestion
    /// </summary>
    public class FrmAffichAbsController
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
        public FrmAffichAbsController()
        {
            absenceAcces = new AbsenceAcces();
            motifAcces = new MotifAcces();
        }

        /// <summary>
        /// Récupère et retourne les absences du personnel selectionne
        /// </summary>
        /// <param name="idPerso">id du personnel</param>
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
        /// Demande de suppression d'une absence
        /// </summary>
        /// <param name="absence">objet absence à supprimer</param>
        public void DelAbsence(Absence absence)
        {
            absenceAcces.DelAbsence(absence);
        }
    }
}
