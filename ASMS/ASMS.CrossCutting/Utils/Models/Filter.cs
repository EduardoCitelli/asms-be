namespace ASMS.CrossCutting.Utils.Models
{
    public class Filter
    {
        public string Field { get; set; }

        public string Operator { get; set; }

        public object Value { get; set; }

        public string Logic { get; set; }

        public List<Filter> Filters { get; set; }
    }
}