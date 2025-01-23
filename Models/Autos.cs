namespace Api2Postgresql.Models
{
    public class Autos
    {
        public int Id { get; set; }
        public required string Marca { get; set; }
        public required string Modelo { get; set; }
        public int  Ano { get; set; }
        public int NroPuertas { get; set; }
        public required string Color { get; set; }
    }
}
