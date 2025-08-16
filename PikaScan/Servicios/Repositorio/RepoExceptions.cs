using System;

namespace PikaScan.Servicios.Repositorio
{
    public class EntityNotFound: Exception
    {

        public EntityNotFound() : base() {

        }

        public EntityNotFound(string msg) : base(msg)
        {

        }

    }
}
