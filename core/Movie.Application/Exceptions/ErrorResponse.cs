using System.Text.Json;

namespace Movie.Application.Exceptions;

public class ErrorResponse
{
    public int Status { get; set; }
    public string? Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}