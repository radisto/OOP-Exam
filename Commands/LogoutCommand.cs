namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;

    class LogoutCommand : AbstractCommand
    {
        public LogoutCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;
            if (this.Forum.IsLogged)
            {
                this.Forum.Output.AppendLine(Messages.LogoutSuccess);
                this.Forum.CurrentUser = null;
            }
            else
            {
                throw new CommandException(Messages.NotLogged);
            }
        }
    }
}
