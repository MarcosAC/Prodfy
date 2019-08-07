using Newtonsoft.Json;
using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prodfy.Services.API
{
    public class ConfiguracaoDispositivoService
    {
        private readonly IDialogService _dialogService;

        public ConfiguracaoDispositivoService()
        {
            _dialogService = new DialogService();
        }

        public async Task<User> ObterDadosConfiguracaoDispositivo(string appKey, string idioma)
        {            
            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(Constantes.BASE_URL)
            };

            try
            {
                string url = $"{Constantes.BASE_URL}l={idioma}&v={Constantes.VERSAO_APP}&a=gsd&k={appKey}";

                HttpResponseMessage response = request.GetAsync(url).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var conteudoResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var dadosDispositivo = JsonConvert.DeserializeObject<User>(conteudoResponse);

                    switch (dadosDispositivo.sinc_stat)
                    {
                        case 0:
                            await _dialogService.AlertAsync("", dadosDispositivo.sinc_msg, "Ok");                            
                            break;
                        case 1:
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
                                ind_ident = dadosDispositivo.ind_ident,
                                ind_inv = dadosDispositivo.ind_inv,
                                ind_mov = dadosDispositivo.ind_mov,
                                ind_per = dadosDispositivo.ind_per,
                                ind_hist = dadosDispositivo.ind_hist,
                                ind_mnt = dadosDispositivo.ind_mnt,
                                ind_exp = dadosDispositivo.ind_exp,
                                ind_atv = dadosDispositivo.ind_atv,
                                uso_liberado = dadosDispositivo.uso_liberado,
                                dth_last_sincr = dadosDispositivo.dth_last_sincr,
                                sinc_stat = dadosDispositivo.sinc_stat
                            };

                            return user;
                    }
                }
            }
            catch (Exception)
            {
                await _dialogService.AlertAsync("Erro", "Erro na configuração. Favor tentar novamente!", "Ok");                
            }
            return null;
        }
    }
}
