using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRestServer.Models
{
    public class DTOBuilder
    {
        public static DTO.Persona Persona(Resources.Persona recPersona)
        {

            DTO.Persona persona = new DTO.Persona();

            persona.Id = Convert.ToInt32(recPersona.Id);
            persona.Nombre = recPersona.Nombre;
            persona.Apellidos = recPersona.Apellidos;
            persona.Rut = Convert.ToInt32(recPersona.Rut);
            persona.DvRut = Convert.ToChar(recPersona.DvRut);
            persona.Edad = Convert.ToInt32(recPersona.Edad);
            persona.Direccion = recPersona.Direccion;
            persona.correo = recPersona.Correo;
            return persona;
        }

    }
}