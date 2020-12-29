namespace Project.Core.Data.Model
{
    public class Match : MatchBase
    {
        public virtual Usuario Usuario { get; set; }
        public Match()
            : base()
        {

        }

    }
}
