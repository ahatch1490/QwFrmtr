using System.Globalization;
using System.Linq;
using System.Text;
namespace QwFrmtr
{
    public class PropertyFormatter
    {
        public string Format(string name)
        {
            var ti = new CultureInfo("en-US",false).TextInfo;
            var values = name.Split("_");
            

            if (values[^1].Contains("DTG"))
            {
                values = name.Replace("_DTG", "_Date").Split("_");
            }
            return values.Aggregate("", (current, s) => current + ti.ToTitleCase(ti.ToLower(s)));

        }
        
    }
}