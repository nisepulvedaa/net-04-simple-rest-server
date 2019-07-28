using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleRestServer.Models.Resources;
using SimpleRestServer.Models.DTO;

namespace SimpleRestServer.Models
{
    public class PersonaModel
    {
        private readonly Models.Resources.RestServerEntities db = new Models.Resources.RestServerEntities();

        public List<DTO.Persona> obtenerPersonas()
        {
            List<DTO.Persona> lista = new List<DTO.Persona>();
            try
            {

                var personas = db.Persona.ToList();
                foreach (var persona in personas)
                {
                    lista.Add(DTOBuilder.Persona(persona));
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SimpleRestServer.Models (obtenerPersonas): " + ex.Message);
                lista = new List<DTO.Persona>();
            }
            return lista;
        }



        public DTO.Persona obtenerPersonaPorId(int id)
        {

            DTO.Persona respuesta = new DTO.Persona();

            try
            {
                Resources.Persona persona = db.Persona.FirstOrDefault(p => p.Id == id);
                return DTOBuilder.Persona(persona);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SimpleRestServer.Models (obtenerPersonaPorId): " + ex.Message);
                respuesta = new DTO.Persona();
            }
            return respuesta;
        }

        public DTO.Persona obtenerPersonaPorRut(int rut)
        {

            DTO.Persona respuesta = new DTO.Persona();

            try
            {
                Resources.Persona persona = db.Persona.FirstOrDefault(p => p.Rut == rut);
                return DTOBuilder.Persona(persona);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SimpleRestServer.Models (obtenerPersonaPorRut): " + ex.Message);
                respuesta = new DTO.Persona();
            }
            return respuesta;
        }



        public bool EliminarPersona(int Id)
        {
            try
            {
                db.EliminarPersona(Id);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SimpleRestServer.Models  (EliminarPersona): " + ex.Message);
                return false;
            }
        }


        public bool IngresarPersona(DTO.Persona persona)
        {
            try
            {
                db.InsertarPersona(persona.Nombre, persona.Apellidos, persona.Rut, persona.DvRut.ToString(), persona.Edad, persona.Direccion, persona.correo);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SimpleRestServer.Models (IngresarPersona): " + ex.Message);
                return false;
            }
        }

        public bool EditarPersona(DTO.Persona persona)
        {
            try
            {
                //db.EditarEmpresa(empresaId, rut, razonSocial, giro, logo, usuarioId);
                db.ActualizarPersona(persona.Id,persona.Nombre, persona.Apellidos, persona.Rut, persona.DvRut.ToString(),persona.Edad,persona.Direccion,persona.correo);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("SimpleRestServer.Models (EditarPersona): " + ex.Message);
                return false;
            }
        }


    }
}