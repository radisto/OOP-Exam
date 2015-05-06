namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;
    using ConsoleForum.Entities.Posts;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            int id = int.Parse(this.Data[1]);
            var question = (Question)this.Forum.CurrentQuestion;
            var answers = question.Answers;

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            else if (!answers.Any(a => a.Id == id))
            {
                throw new CommandException(Messages.NoAnswer);
            }
            else if (question.Author.Username != this.Forum.CurrentUser.Username)
            {
                throw new CommandException(Messages.NoPermission);
            }
            else
            {
                var bestAnswer = answers.FirstOrDefault(a => a.Id == id);
                question.Answers.Remove(bestAnswer);
                var theBestAnswer = new BestAnswer(bestAnswer.Body, bestAnswer.Id, bestAnswer.Author);
                question.Answers.Add(theBestAnswer);
                this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, id));
            }
        }
    }
}
