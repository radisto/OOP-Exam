namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using ConsoleForum.Commands;

    class Question : IQuestion
    {
        public Question(string title, string body, int id, IUser author)
        {
            this.Title = title;
            this.Body = body;
            this.Id = id;
            this.Author = author;
            this.Answers = new List<IAnswer>();
        }

        public string Title { get; set; }

        public IList<IAnswer> Answers { get; set; }

        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("[ Question ID: {0} ]", this.Id).AppendLine();
            output.AppendFormat("Posted by: {0}", this.Author.Username).AppendLine();
            output.AppendFormat("Question Title: {0}", this.Title).AppendLine();
            output.AppendFormat("Question Body: {0}", this.Body).AppendLine();
            output.AppendLine("====================");
            if (this.Answers.Count == 0)
            {
                output.AppendLine("No answers");
            }
            else
            {
                output.AppendLine("Answers:");
                this.Answers.OrderByDescending(a => a is BestAnswer).ThenBy(a => a.Id).ToList().ForEach(a => output.Append(a.ToString()));
            }
            return output.ToString();
        }
    }
}
