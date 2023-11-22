namespace caixa_eletronico.Models
{
    public class Saque
    {
        
        public Resultado Resultado { get; set; }
        public Saque()
        {
            Resultado = new Resultado();
        }
    }

    public class Resultado
    {
        public string Mensagem { get; set; }
        public List<int> NotasSaque { get; set; }
    }

}
