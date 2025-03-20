using System.Text.Json.Serialization;
using Skeleton.Application.Common;

namespace Skeleton.Application.Services.Country;

public class CountryDto : BaseDto
{
    public int Id { get; set; }
    public required string CountryCode { get; set; }
    public required string CountryName { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? CreatedAt { get; set; }
   
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CreatedBy { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? UpdateAt { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? UpdateBy { get; set; }

}