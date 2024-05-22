namespace Movie.Application.DTOs;

public class ErrorResponse
{
    public int Status { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public string Instance { get; set; }
    public string Type { get; set; }
}