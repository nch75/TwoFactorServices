using Microsoft.Extensions.Options;
using TwoFactorService.Configurations;

namespace TwoFactorService.Services
{
    public class TwoFactorService
    {
        private readonly CodeStorageService _codeStorageService;
        private readonly IOptions<TwoFactorSettings> _settings;

        public TwoFactorService(CodeStorageService codeStorageService, IOptions<TwoFactorSettings> settings)
        {
            _codeStorageService = codeStorageService;
            _settings = settings;
        }

        public bool CanSendCode(string phone)
        {
            return _codeStorageService.CountCodes(phone) < _settings.Value.MaxConcurrentCodes;
        }

        public string GenerateAndStoreCode(string phone)
        {
            // For simplicity, generating a 6-digit code
            var code = new Random().Next(100_000, 999_999).ToString();
            _codeStorageService.StoreCode(phone, code);
            return code;
        }

        public bool ValidateCode(string phone, string code)
        {
            return _codeStorageService.ValidateCode(phone, code);
        }
    }
}
