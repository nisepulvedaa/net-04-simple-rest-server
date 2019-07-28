using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleRestServer.Models.DTO;


namespace SimpleRestServer.Controllers
{
    public class PersonController : ApiController
    {

        // GET: api/Person
        public List<Persona> Get()
        {
            var personaModel = new Models.PersonaModel();
            List<Persona> lista = personaModel.obtenerPersonas();
            return lista;
        }

        // GET: api/Person/5
        public Persona Get(int id)
        {
            var personaModel = new Models.PersonaModel();
            Persona lista = personaModel.obtenerPersonaPorId(id);
            return lista;


        }

        // POST: api/Person
        public IHttpActionResult Post([FromBody]Persona value)
        {

            var personaModel = new Models.PersonaModel();
            if (personaModel.IngresarPersona(value))
            {
                var persona = personaModel.obtenerPersonaPorRut(value.Rut);
                return Ok(persona);

            }
            else
            {
                return NotFound();

            }
        }

        // PUT: api/Person/5
        public IHttpActionResult Put(int id, [FromBody]Persona value)
        {
            var personaModel = new Models.PersonaModel();
            if (personaModel.EditarPersona(value))
            {
                var persona = personaModel.obtenerPersonaPorRut(value.Rut);
                return Ok(persona);

               
            }
            else
            {
                return NotFound();

            }
        }

        // DELETE: api/Person/5
        public IHttpActionResult Delete(int id)
        {
            var personaModel = new Models.PersonaModel();
            var persona = personaModel.obtenerPersonaPorId(id);
            if (personaModel.EliminarPersona(id))
            {
                return Ok(persona);
            }
            else
            {
                return NotFound();
            }

        }

       
    }
}
