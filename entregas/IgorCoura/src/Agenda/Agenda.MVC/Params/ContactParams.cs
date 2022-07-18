

namespace Agenda.MVC.Params
{
    public class ContactParams
    {
        private Dictionary<string, string?> dictionary = new Dictionary<string, string?>();
        public ContactParams()
        {
            dictionary.Add("Name", null);
            dictionary.Add("UserId", null);
            dictionary.Add("DDD", null);
            dictionary.Add("Number", null);
            dictionary.Add("Skip", null);
            dictionary.Add("Take", null);
        }

        public void SetParam(string? key, string? value)
        {
            if(key != null && dictionary.ContainsKey(key))
                dictionary[key] = value;
        }

        public IEnumerable<string> GetParam()
        {
            return dictionary.Keys;
        }
        public Dictionary<string, string>? Query()
        {
            if (dictionary.Count > 0)
            {
                return dictionary;
            }

            return null;
        }
    }
}
