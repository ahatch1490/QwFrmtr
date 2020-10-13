using QwFrmtr;
using Xunit;
using Shouldly;

namespace QwFrmtrTest
{
    public class PropertyFormatterTest
    {
        [Fact]
        public void ShouldParseQwFormattedName()
        {
            var value = "SOME_VALUE";
            var expected = "SomeValue";
            var formatter = new PropertyFormatter();
            formatter.Format(value).ShouldBe(expected);
        }
        
        [Fact]
        public void ShouldParseQwDates()
        {
            var value = "REVERSE_DTG";
            var expected = "ReverseDate";
            var formatter = new PropertyFormatter();
            formatter.Format(value).ShouldBe(expected);
        }
    }
}
    
    


