using MirthConnectFX.Model;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class CodeTemplateService : ServiceBase, ICodeTemplateService
    {
        public CodeTemplateService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "codeTemplates")
        {
        }

        public CodeTemplate GetCodeTemplate(string templateId)
        {
            var request = CreateRequest().ForOperation(templateId);

            var response = request.ExecuteGet();
            var template = response.Content.ToObject<CodeTemplate>();

            return template;
        }
        public string GetRawCodeTemplateXML(string templateId)
        {
            var request = CreateRequest().ForOperation(templateId);

            var response = request.ExecuteGet();
            return response.Content;
        }

        public void UpdateCodeTemplates(CodeTemplateList codeTemplates)
        {
            var request = CreateRequest().ForOperation(Operations.CodeTemplates.UpdateCodeTemplatse);
            request.AddPostData("codeTemplates", codeTemplates.ToXml());

            request.Execute();
        }
    }
}