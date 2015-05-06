namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;
    using ConsoleForum.Entities.Posts;

    public class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            int questionId = int.Parse(this.Data[1]);
            var questions = this.Forum.Questions;

            if (!questions.Any(q => q.Id == questionId))
            {
                throw new CommandException(Messages.NoQuestion);
            }
            else
            {
                var question = (Question)questions.FirstOrDefault(q => q.Id == questionId);
                this.Forum.CurrentQuestion = question;
                this.Forum.Output.Append(question.ToString());
            }
        }
    }
}
