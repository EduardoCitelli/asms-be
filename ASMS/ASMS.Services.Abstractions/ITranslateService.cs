using GTranslate.Results;

namespace ASMS.Services.Abstractions
{
    public interface ITranslateService
    {
        Task<GoogleTranslationResult> TranslateAsync(string text, string toLanguage, string? fromLanguage = null);
    }
}