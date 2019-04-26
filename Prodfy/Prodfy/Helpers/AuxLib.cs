using System;
using System.Collections.Generic;
using System.Text;

namespace Prodfy.Helpers
{
    public class AuxLib
    {
        private string _data;
        public string Data
        {
            get => _data;
            set
            {
                if (value == null)
                {
                    _data = "";
                }                
            }
        }

        public string ObterDDMMAAAA(string data)
        {
            if (string.IsNullOrEmpty(data))
                return data;

            var tempA = data.Split(' ');
            var tempD = tempA[0].Split('/');
            string ret = $"{tempD[2]}/{tempD[1]}/{tempD[0]}";

            return ret;
        }

        public string ObterDDMMAAAAHHMMSS(string data)
        {
            if (string.IsNullOrEmpty(data))
                return data;

            string Hora = string.Empty;
            string Minutos = string.Empty;
            string Segundos = string.Empty;

            var tempInfo = data.Split(' ');
            var tempHora = tempInfo[1].Split(':');

            switch (tempHora.Length)
            {
                case 1:
                    Hora = tempHora[0];

                    if (Hora == string.Empty)
                        Hora = "00";

                    Minutos = "00";
                    Segundos = "00";
                    break;
                case 2:
                    Hora = tempHora[0];
                    Minutos = tempHora[1];

                    if (Hora == string.Empty)
                        Hora = "00";

                    if (Minutos == string.Empty)
                        Minutos = "00";

                    Segundos = "00";
                    break;
                case 3:
                    Hora = tempHora[0];
                    Minutos = tempHora[1];
                    Segundos = tempHora[2];

                    if (Hora == string.Empty)
                        Hora = "00";

                    if (Minutos == string.Empty)
                        Minutos = "00";

                    if (Segundos == string.Empty)
                        Segundos = "00";
                    break;
            }

            //if (tempHora.Length == 1)
            //{
            //    Hora = tempHora[0];

            //    if (Hora == string.Empty)
            //        Hora = "00";

            //    Minutos = "00";
            //    Segundos = "00";
            //}

            //if (tempHora.Length == 2)
            //{
            //    Hora = tempHora[0];
            //    Minutos = tempHora[1];

            //    if (Hora == string.Empty)
            //        Hora = "00";

            //    if (Minutos == string.Empty)
            //        Minutos = "00";

            //    Segundos = "00";
            //}

            //if (tempHora.Length == 3)
            //{
            //    Hora = tempHora[0];
            //    Minutos = tempHora[1];
            //    Segundos = tempHora[2];

            //    if (Hora == string.Empty)
            //        Hora = "00";

            //    if (Minutos == string.Empty)
            //        Minutos = "00";

            //    if (Segundos == string.Empty)
            //        Segundos = "00";
            //}

            var tempData = tempInfo[0].Split('-');
            string ret = $"{tempData[2]}/{tempData[1]}/{tempData[0]} {Hora}:{Minutos}:{Segundos}";

            return ret;
        }
    }
}
