namespace Conversor.Infra.Json;

using System.Text.Json;

class JsonFieldExtractor
{
  private string Content;

  public JsonFieldExtractor(string content)
  { Content = content; }

  public bool GetFieldDouble(string field, out double target)
  {
    try
    {
      var jsonDoc = JsonDocument.Parse(Content);
      var root = jsonDoc.RootElement;
      if (root.TryGetProperty(field, out JsonElement element))
      {
        target = element.GetDouble();
        return true;
      }
      else
      {
        target = 0;
        return false;
      }
    }
    catch (JsonException)
    {
      target = 0;
      return false;
    }
  }
}
