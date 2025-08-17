namespace Mail;

public abstract class ReactEmailTemplate(string htmlFilePath)
{
    public string HtmlFilePath { get; } = htmlFilePath;

    public async Task<string> GetHtmlBodyAsync()
    {
        var htmlContent = await File.ReadAllTextAsync(HtmlFilePath);

        GetType()
            .GetProperties()
            .ToList()
            .ForEach(prop =>
            {
                var value = prop.GetValue(this)?.ToString() ?? string.Empty;
                htmlContent = htmlContent.Replace(
                    $"% {prop.Name} %",
                    value,
                    StringComparison.InvariantCultureIgnoreCase);
            });

        return htmlContent;
    }
}