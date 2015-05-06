namespace ConsoleForum.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ConsoleForum.Entities.Users;
    using ConsoleForum.Contracts;
    using ConsoleForum.Utility;
    using ConsoleForum.Entities.Posts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;
            var questions = this.Forum.Questions;
            if (!questions.Any())
            {
                throw new CommandException(Messages.NoQuestions);
            }
            else
            {
                foreach (Question question in questions)
                {
                    this.Forum.Output.Append(question.ToString());
                }
            }
        }
    }
}
