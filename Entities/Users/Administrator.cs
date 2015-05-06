namespace ConsoleForum.Entities.Users
{
    using ConsoleForum.Contracts;
    using System.Collections.Generic;

    class Administrator : User, IAdministrator
    {
        public Administrator(int id, string name, string password, string email)
            :base(id, name, password, email)
        {
        }
    }
}
