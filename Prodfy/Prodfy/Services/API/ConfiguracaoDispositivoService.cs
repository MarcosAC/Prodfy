using Newtonsoft.Json;
using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;

namespace Prodfy.Services.API
{
    public class ConfiguracaoDispositivoService
    {
        //private static readonly string BaseUrl = /*Contantes.BASE_PROTOCOL +*/ Contantes.BASE_URL + Contantes.BASE_API;

        public static void DadosConfiguracaoDispositivo(string appKey, string idioma)
        {
            //string url = BaseUrl;

            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(Contantes.BASE_URL)
            };

            //string parametros = "{" + '"' + "" + '"' + "}";

            //string key = appKey;
            
            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("l", idioma),
                new KeyValuePair<string, string>("a", "gsd"),
                new KeyValuePair<string, string>("k", appKey)
            });

            try
            {
                HttpResponseMessage response = request.PostAsync(Contantes.BASE_URL, parametros).GetAwaiter().GetResult();                

                if (response.IsSuccessStatusCode)
                {
                    var conteudoResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var dadosDispositivo = JsonConvert.DeserializeObject<User>(conteudoResponse);

                    var user = new User
                    {
                        disp_num = dadosDispositivo.disp_num,
                        nome = dadosDispositivo.nome,
                        empresa = dadosDispositivo.empresa
                    };
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
