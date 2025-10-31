using Fluid;
using POIMapper.Models;
using System.Text;
using System.Text.Json;

namespace POIMapper.Services;

public class ExportService
{
    private readonly FluidParser _parser;

    public ExportService()
    {
        _parser = new FluidParser();
    }

    public string ExportAsJson(List<POI> pois)
    {
        return JsonSerializer.Serialize(pois, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
    }

    public string ExportAsCsv(List<POI> pois)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Name,Description,Category,Latitude,Longitude,CreatedAt");
        
        foreach (var poi in pois)
        {
            sb.AppendLine($"\"{poi.Name}\",\"{poi.Description}\",\"{poi.Category}\",{poi.Latitude},{poi.Longitude},\"{poi.CreatedAt:O}\"");
        }
        
        return sb.ToString();
    }

    public async Task<string> ExportWithTemplate(List<POI> pois, string template)
    {
        if (string.IsNullOrWhiteSpace(template))
            return string.Empty;

        try
        {
            var sb = new StringBuilder();
            
            foreach (var poi in pois)
            {
                if (_parser.TryParse(template, out var parsedTemplate, out var error))
                {
                    var context = new TemplateContext(poi);
                    context.SetValue("name", poi.Name);
                    context.SetValue("description", poi.Description);
                    context.SetValue("category", poi.Category);
                    context.SetValue("lat", poi.Latitude);
                    context.SetValue("lon", poi.Longitude);
                    context.SetValue("latitude", poi.Latitude);
                    context.SetValue("longitude", poi.Longitude);
                    context.SetValue("created", poi.CreatedAt.ToString("O"));
                    
                    var result = await parsedTemplate.RenderAsync(context);
                    sb.AppendLine(result);
                }
                else
                {
                    return $"Template error: {error}";
                }
            }
            
            return sb.ToString();
        }
        catch (Exception ex)
        {
            return $"Export error: {ex.Message}";
        }
    }
}
