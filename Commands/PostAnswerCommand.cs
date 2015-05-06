namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;
    using ConsoleForum.Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            string body = this.Data[1];

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            else if(this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            else
            {
                int id = this.Forum.Questions.ToList().Select(x => x.Answers.Count).Sum();
                var question = (Question)this.Forum.CurrentQuestion;
                var answer = new Answer(body, id + 1, this.Forum.CurrentUser);
                question.Answers.Add(answer);
                this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, question.Answers.Last().Id));
            }
        }
    }
}
