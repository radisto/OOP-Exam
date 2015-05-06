using ConsoleForum.Contracts;
using System.Text;
namespace ConsoleForum.Entities.Posts
{
    class BestAnswer : Answer, IAnswer
    {
        public BestAnswer(string body, int id, IUser author)
            : base(body, id, author)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("********************");
            output.Append(base.ToString());
            output.AppendLine("********************");
            return output.ToString();
        }
    }
}
