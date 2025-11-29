using System.Text.RegularExpressions;

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
                htmlContent = Regex.Replace(
                    htmlContent,
                    $"%\\s*{prop.Name}\\s*%",
                    value,
                    RegexOptions.IgnoreCase);
            });

        return htmlContent;
    }
}