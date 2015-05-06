namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (users.Any(u => u.Username == username && u.Password == password) && !this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, username));
                this.Forum.CurrentUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            }
            else if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }
            else
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
        }
    }
}
