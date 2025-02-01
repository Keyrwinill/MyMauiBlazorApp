using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Methods
{
    public class DictionaryMethods
    {
        // 1-1 string mapping definition
        public Dictionary<string, string> forward = new();
        public Dictionary<string, string> reverse = new();

        public void Add(string key, string value) 
        {
            // Not allowed to create repeatedly
            if (forward.ContainsKey(key))
                throw new ArgumentException("Dupicate key or value detected.");

            forward[key] = value;
            reverse[value] = key;
        }

        public string Get(string input)
        {
            if (forward.TryGetValue(input, out var value))
                return value;
            if (reverse.TryGetValue(input, out var key)) 
                return key;
            return "";
        }
    }
}
