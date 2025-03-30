using System.Text.Json.Serialization;

namespace UniversityCatalog.Core.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public List<Teacher>? Teachers { get; set; }
    
}