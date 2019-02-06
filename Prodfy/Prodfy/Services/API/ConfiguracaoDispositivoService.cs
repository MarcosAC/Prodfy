using Newtonsoft.Json;
using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Prodfy.Services.API
{
    public class ConfiguracaoDispositivoService
    {
        public static User DadosConfiguracaoDispositivo(string appKey, string idioma)
        {
            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(Contantes.BASE_URL)
            };
            
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
                        disp_id = dadosDispositivo.disp_id,
                        disp_num = dadosDispositivo.disp_num,
                        senha = dadosDispositivo.senha,
                        nome = dadosDispositivo.nome,                        
                        sobrenome = dadosDispositivo.sobrenome,
                        empresa = dadosDispositivo.empresa,
                        autosinc = dadosDispositivo.autosinc,
                        autosinc_time = dadosDispositivo.autosinc_time,
                        sinc_url = dadosDispositivo.sinc_url,
                        app_key = dadosDispositivo.app_key,
                        lang = dadosDispositivo.lang,
                        ind_ident = dadosDispositivo.ind_inv,
                        ind_inv = dadosDispositivo.ind_inv,
                        ind_per = dadosDispositivo.ind_per,
                        ind_hist = dadosDispositivo.ind_hist,
                        ind_evo = dadosDispositivo.ind_evo,
                        ind_mnt = dadosDispositivo.ind_mnt,
                        ind_exp = dadosDispositivo.ind_exp,
                        ind_atv = dadosDispositivo.ind_atv,
                        uso_liberado = dadosDispositivo.uso_liberado,
                        dht_last_sincr = dadosDispositivo.dht_last_sincr
                    };

                    return user;
                }
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Erro", "Erro na configuração. Favor tentar novamente!", "Ok");                
            }

            return null;
        }
    }
}
