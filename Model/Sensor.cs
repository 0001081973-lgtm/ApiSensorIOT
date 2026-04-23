namespace ApiSensoresIOT.Model
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public double Valor { get; set; }
        public string Unidade { get; set; }
        public DateTime DataLeitura { get; set; }
        public string Localizacao { get; set; }
        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}