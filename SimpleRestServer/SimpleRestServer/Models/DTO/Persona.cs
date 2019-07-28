﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleRestServer.Models.DTO
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Rut { get; set; }
        public char DvRut { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string correo { get; set; }


    }
}