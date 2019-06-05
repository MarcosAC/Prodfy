using System;

namespace Prodfy.Utils
{
    public class CalculaIdade
    {
        public static string CalcularPorDataIniciaDataFinal(DateTime dataInicial, DateTime dataFinal)
        {
            var idade = dataFinal - dataInicial;
            return Convert.ToString(idade.Days);
        }
    }
}
