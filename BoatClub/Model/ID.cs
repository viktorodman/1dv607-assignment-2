using System;
using System.Linq;
using System.Text;

namespace Model
{
    public class ID
    {
        private string _value;
        public string Value { get => _value; }

        public ID()
        {
            _value = GenerateID();
        }

        private string GenerateID()
        {
            // https://stackoverflow.com/questions/11313205/generate-a-unique-id
            StringBuilder builder = new StringBuilder();
            Enumerable
            .Range(65, 26)
            .Select(e => ((char)e).ToString())
            .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
            .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
            .OrderBy(e => Guid.NewGuid())
            .Take(8)
            .ToList().ForEach(e => builder.Append(e));

            return builder.ToString();
        }
    }
}