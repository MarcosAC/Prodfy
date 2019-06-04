using System;

namespace Prodfy.Utils
{
    public class CalculaIdade
    {
        public static int CalcularPorDataIniciaDataFinal(DateTime dataInicial, DateTime dataFinal)
        {
            var idade = dataFinal - dataInicial;
            return Convert.ToInt32(idade);
        }
    }
}
