using AppMediatek.Model;
using System;
using System.Collections.Generic;
using Serilog;

namespace AppMediatek.dal
{
    /// <summary>
    /// Classe permettant de gérer les demandes concernant les services
    /// </summary>
    public class ServiceAcces
    {
        /// <summary>
        /// Instance unique de l'accès aux données
        /// </summary>
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public ServiceAcces()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les services
        /// </summary>
        /// <returns>liste des services</returns>
        public List<Service> GetServices()
        {
            List<Service> lesServices = new List<Service>();
            if (access.Manager != null)
            {
                string req = "select s.idservice as idservice, s.nom as nom ";
                req += "from service s;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        Log.Debug("ServiceAccess.GetServices nb records = {0}", records.Count);
                        foreach (Object[] record in records)
                        {
                            Service service = new Service((int)record[0], (string)record[1]);
                            lesServices.Add(service);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("ServiceAccess.GetServices catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
            return lesServices;
        }
    }
}