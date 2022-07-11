namespace Agenda.MVC.Params
{
    public class UserParams
    {
        private Dictionary<string, string?> dictionary = new Dictionary<string, string?>();
        public UserParams()
        {
            dictionary.Add("Name", null);
            dictionary.Add("Username", null);
            dictionary.Add("Email", null);
            dictionary.Add("Skip", null);
            dictionary.Add("Take", null);
        }

        public void SetParam(string? key, string? value)
        {
            if (key != null && dictionary.ContainsKey(key))
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
