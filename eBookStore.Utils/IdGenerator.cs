namespace eBookStore.Utils
{
    public static class IdGenerator
    {
        private static readonly Dictionary<string, int> _currentMaxIds = new Dictionary<string, int>
        {
            { "User", 1 },  
            { "Author", 1 },  
            { "Publisher", 1 },  
            { "Book", 1 },
            { "Role", 1 },
            { "BookAuthor", 1 },
        };
        public static string GenerateId(string type)
        {
            if (!_currentMaxIds.TryGetValue(type, out var currentMaxId))
            {
                throw new ArgumentException("Invalid type specified");
            }
            _currentMaxIds[type]++;
            string prefix = type[..1].ToUpper(); 
            string newId = $"{prefix}{currentMaxId:D5}";
            return newId;
        }
    }
}