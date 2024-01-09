namespace DriversApi.Models
{
    public class DriverDtoRequest
    {
        public string? Name { get; set; } = null!;
        public int Number { get; set; }
        public string? Team { get; set; } = null!;
    }
}
