namespace AbstractFactory.Bridge
{
    public class AnnualReport : IBridgeReport
    {
        private readonly ILanguage _language;

        public AnnualReport(ILanguage language)
        {
            _language = language;
        }

        public string MakeReport()
        {
           return  $"Type: AnnualReport, {_language.Make()}";
        }
    }
}
