﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {
        Data.Database.PersonaAdapter PersonaData {get; set; }

        public PersonaLogic()
        {
            PersonaData = new Data.Database.PersonaAdapter();
        }

        public Persona GetOne(int ID)
        {
            try
            {
                return PersonaData.GetOne(ID);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public Persona GetOne(string nameuser)
        {
            try
            {
                return PersonaData.GetOne(nameuser);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
        public Persona GetOneLeg(int legajo)
        {
            try
            {
                return PersonaData.GetOneLeg(legajo);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }
        
    
        public List<Persona> GetAll()
        {
            try
            {
                return PersonaData.GetAll();
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Save(Persona persona)
        {
            try
            {
                PersonaData.Save(persona);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        public void Delete(int ID)
        {
            try
            {
                PersonaData.Delete(ID);
            }
            catch (Exception e)
            {
                Util.Logger.Log(e);
                throw;
            }
        }

        /// <summary>
        /// Devuelve verdadero si el nombre de usuario esta utilizado
        /// </summary>
        /// <param name="nombreUsu"></param>
        /// <returns></returns>
        static public bool ValidaUsuario(string nombreUsu)
        {  
            bool retorno = true;
            Persona p = new PersonaLogic().GetOne(nombreUsu);
            if (p.NombreUsuario != null && p.Baja == false)
            {
                retorno = false;
            }
            return retorno;
        }
        
        /// <summary>
        /// Devuelve verdadero si el numero de legajo esta utilizado
        /// </summary>
        /// <param name="numlegajo"></param>
        /// <returns></returns>
        static public bool ValidaLegajo(int numlegajo)
        {   
            bool retorno = true;
            Persona p = new PersonaLogic().GetOneLeg(numlegajo);
            if (p.Nombre != null && p.Baja == false)
            {
                retorno = false;
            }
            return retorno;
        }


    }
}
