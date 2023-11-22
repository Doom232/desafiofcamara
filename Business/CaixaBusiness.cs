using caixa_eletronico.Models;

namespace caixa_eletronico.Business;
public class CaixaBusiness
{
    public Dictionary<int, int> Notas_diponiveis = new Dictionary<int, int> { { 10, 2 }, { 20, 2 }, { 50, 2 }, { 100, 2 } };
    private string Mensagem = string.Empty;
   
    public Saque GetValores(Pedido info)
    {

        Saque saque = GetSaque(info.ValorSaque);
        return saque;
    }

    private Saque GetSaque(float valor)
    {
        try
        {
            Saque Saque = new Saque();
            var resto = valor % 10;
            if (resto == 0)
            {
                List<int> Notas = GetNotas(valor);
                if (Mensagem != String.Empty)
                {
                    Saque.Resultado.Mensagem = Mensagem;
                    return Saque;
                }
                Saque.Resultado.Mensagem = "Saque Realizado com Sucesso";
                Saque.Resultado.NotasSaque = Notas;
                return Saque;
            }
            else
            {
                Saque.Resultado.Mensagem = "Não é possivel efetuar o saque do valor informado.";
                return Saque;
            }
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar executar o metodo GetSaque");
        }
    }

    private List<int> GetNotas(float valorSaque)
    {
        try
        {
            List<int> notas = new List<int>();
            float valor_restante = valorSaque;
            while (valor_restante > 0)
            {
                var nota_proxima = 0;
                foreach (var item in Notas_diponiveis)
                {
                    if (item.Key > valor_restante)
                    {
                        break;
                    }
                    if (item.Value == 0)
                    {
                        if (item.Key == valor_restante)
                        {
                            break;
                        }
                        continue;
                    }
                    if (item.Key >= nota_proxima && item.Key <= valor_restante)
                    {
                        nota_proxima = item.Key;
                    }
                }

                if (nota_proxima == 0)
                {
                    Mensagem = $"Não foi possivel efetuar o saque pois não temos notas de R${valor_restante} disponiveis no momento.";
                    return notas;
                }
                Notas_diponiveis[nota_proxima] = Notas_diponiveis[nota_proxima] - 1;
                valor_restante = valor_restante - nota_proxima;
                notas.Add(nota_proxima);
            }

            return notas;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar executar o metodo GetNotas");
        }
    }
}

