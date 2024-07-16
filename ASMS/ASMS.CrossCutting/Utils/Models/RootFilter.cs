namespace ASMS.CrossCutting.Utils.Models
{
    public class RootFilter
    {
        public string Logic { get; set; } = "and";

        public List<Filter> Filters { get; set; } = new List<Filter>();
    }
}
