namespace TwoFactorService.Services
{
    public class CodeStorageService
    {
        private readonly Dictionary<string, List<string>> _codeStorage = new();

        public void StoreCode(string phone, string code)
        {
            if (!_codeStorage.ContainsKey(phone))
            {
                _codeStorage[phone] = new List<string>();
            }
            _codeStorage[phone].Add(code);
        }

        public bool ValidateCode(string phone, string code)
        {
            return _codeStorage.ContainsKey(phone) && _codeStorage[phone].Contains(code);
        }

        public void RemoveCode(string phone, string code)
        {
            if (_codeStorage.ContainsKey(phone))
            {
                _codeStorage[phone].Remove(code);
            }
        }

        public int CountCodes(string phone)
        {
            return _codeStorage.ContainsKey(phone) ? _codeStorage[phone].Count : 0;
        }
    }
}
