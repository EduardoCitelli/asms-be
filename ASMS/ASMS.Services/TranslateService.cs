using ASMS.Services.Abstractions;
using GTranslate.Results;
using GTranslate.Translators;

namespace ASMS.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly GoogleTranslator2 _translator;

        public TranslateService()
        {
            _translator = new GoogleTranslator2();
        }

        public async Task<GoogleTranslationResult> TranslateAsync(string text, string toLanguage, string? fromLanguage = null)
        {
            return await _translator.TranslateAsync(text, toLanguage, fromLanguage);
        }
    }
}
