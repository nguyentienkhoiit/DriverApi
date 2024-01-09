namespace DriversApi.Models
{
    public class DriverDtoResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; } = null!;
        public int Number { get; set; }
        public string? Team { get; set; } = null!;
    }
}
