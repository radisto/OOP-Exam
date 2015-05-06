namespace ConsoleForum.Entities.Posts
{
    using ConsoleForum.Contracts;
    using System.Text;

    class Answer : IAnswer
    {
        public Answer(string body, int id, IUser author)
        {
            this.Body = body;
            this.Id = id;
            this.Author = author;
        }
        public int Id { get; set; }

        public string Body { get; set; }

        public IUser Author { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendFormat("[ Answer ID: {0} ]", this.Id).AppendLine();
            output.AppendFormat("Posted by: {0}", this.Author.Username).AppendLine();
            output.AppendFormat("Answer Body: {0}", this.Body).AppendLine();
            output.AppendLine("--------------------");
            return output.ToString();
        }
    }
}
