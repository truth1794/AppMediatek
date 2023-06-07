using System;
using AppMediatek.dal;
using AppMediatek.Model;

namespace AppMediatek.controller
{
    /// <summary>
    /// Contrôleur de FrmAuthentification
    /// </summary>
    public class FrmAuthentificationController
    {
        /// <summary>
        /// objet d'accès aux opérations possibles sur responsable
        /// </summary>
        private readonly ResponsableAcces responsableAcces;

        /// <summary>
        /// Récupère l'acces aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            responsableAcces = new ResponsableAcces();
        }

        /// <summary>
        /// Vérifie l'authentification
        /// </summary>
        /// <param name="responsable">objet contenant les informations de connexion</param>
        /// <returns> vrai si les informations de connexion sont correctes</returns>
        public Boolean ControleAuthentification(Responsable responsable)
        {
            return responsableAcces.ControleAuthentification(responsable);
        }

    }
}
