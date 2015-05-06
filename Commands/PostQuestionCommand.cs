namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;
    using ConsoleForum.Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string title = this.Data[1];
            string body = this.Data[2];
            var questions = this.Forum.Questions;
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            else
            {
                Question newQuestion = new Question(title, body, questions.Count + 1, this.Forum.CurrentUser);
                questions.Add(newQuestion);
                this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, questions.Last().Id));
            }
        }
    }
}
