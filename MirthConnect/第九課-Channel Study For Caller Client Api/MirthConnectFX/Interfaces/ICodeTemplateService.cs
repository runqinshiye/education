using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface ICodeTemplateService
    {
        CodeTemplate GetCodeTemplate(string templateId);
        void UpdateCodeTemplates(CodeTemplateList codeTemplates);
        string GetRawCodeTemplateXML(string templateId);
    }
}