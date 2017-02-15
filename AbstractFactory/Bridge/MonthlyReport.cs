namespace AbstractFactory.Bridge
{
    public class MonthlyReport : IBridgeReport
    {
        private readonly ILanguage _language;

        public MonthlyReport(ILanguage language)
        {
            _language = language;
        }

        public string MakeReport()
        {
            return $"Type: MonthlyReport, {_language.Make()}";
        }
    }
}
