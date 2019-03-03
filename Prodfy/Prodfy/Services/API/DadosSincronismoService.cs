﻿using Newtonsoft.Json;
using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prodfy.Services.API
{
    public class DadosSincronismoService
    {
        private readonly IDialogService _dialogService;

        public DadosSincronismoService()
        {
            _dialogService = new DialogService();
        }

        public async Task<Sincronismo> ObterDadosSincronismo(string appKey, string idioma)
        {
            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(Contantes.BASE_URL)
            };

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("l", idioma),
                new KeyValuePair<string, string>("a", "s"),
                new KeyValuePair<string, string>("k", appKey)
            });

            try
            {
                HttpResponseMessage response = request.PostAsync(Contantes.BASE_URL, parametros).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    var conteudoResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var dadosSincronismo = JsonConvert.DeserializeObject<User>(conteudoResponse);

                    var sincronismo = new Sincronismo
                    {
                        ind_ident = dadosSincronismo.ind_ident,
                        ind_inv = dadosSincronismo.ind_inv,
                        ind_per = dadosSincronismo.ind_per,
                        ind_hist = dadosSincronismo.ind_hist,
                        ind_evo = dadosSincronismo.ind_evo,
                        ind_mnt  = dadosSincronismo.ind_mnt,
                        ind_exp = dadosSincronismo.ind_exp,
                        ind_atv = dadosSincronismo.ind_atv
                    };
                    return sincronismo;
                }
            }
            catch (Exception ex)
            {
                await _dialogService.AlertAsync("Erro", ex.ToString(), "Ok");
            }
            return null;
        }

        public async Task<Sincronismo> UploadDadosParaSincronisar(string appKey, string idioma, ArrayList dadosSincrismo)
        {
            HttpClient request = new HttpClient
            {
                BaseAddress = new Uri(Contantes.BASE_URL)
            };

            string dados = JsonConvert.SerializeObject(dadosSincrismo, Formatting.Indented); 

            string dadosParaUpload = "{" + dados + "}";            

            FormUrlEncodedContent parametros = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("l", idioma),
                new KeyValuePair<string, string>("a", "u"),
                new KeyValuePair<string, string>("k", appKey),
                new KeyValuePair<string, string>("d", dadosParaUpload)
            });

            try
            {
                HttpResponseMessage response = await request.PostAsync(Contantes.BASE_URL, parametros);

                if (response.IsSuccessStatusCode)
                {
                    var conteudoResponse = await response.Content.ReadAsStringAsync();

                    var dadosResponse = JsonConvert.DeserializeObject<Sincronismo>(conteudoResponse);                    

                    switch (dadosResponse.sinc_stat)
                    {
                        case 0:
                            await _dialogService.AlertAsync("Erro", dadosResponse.sinc_msg, "Ok");                            
                            break;
                        case 1:
                            await _dialogService.AlertAsync("Sucesso!", dadosResponse.sinc_msg, "Ok");                            
                            break;
                    }

                    return dadosResponse;
                }
            }
            catch (Exception)
            {
                await _dialogService.AlertAsync("Erro", "Erro de sincronização.", "Ok");
            }

            return null;
        }
    }
}
