using System;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;
using AyCWeb.Models;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace AyCWeb.Controllers
{
    public class BaseController : Controller
    {
        private const string Token = "Token";
        private const string Usuario = "Usuario";
        private const string Autenticado = "esautenticado";
        private static HttpClient cliente;
        private HttpClientHandler handler;
        private string Url_Api = null;
    

        public BaseController()
        {
            if (string.IsNullOrEmpty(Url_Api))
             
            handler = new HttpClientHandler() { AllowAutoRedirect = true, Proxy = null, UseProxy = false };
       

        }

 

        /*método para loguearse*/
        public async Task<bool> LoginBack(string user,string contrasena)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "Account/Login");
            var jsonstring = "{'User':'" + user+"','Password':'"+contrasena+"'}";
            request.Content = new StringContent(jsonstring,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage response =cliente.SendAsync(request).Result;
            if (response.IsSuccessStatusCode)
            {
                string token = await response.Content.ReadAsStringAsync();
                HttpContext.Session.SetString(Token, token);
                HttpContext.Session.SetString(Usuario,user);
                HttpContext.Session.SetInt32(Autenticado, 1);
            
            }
            //cliente.Dispose();
            return response.IsSuccessStatusCode;
        }

   
        
        public async Task<ResponseApi> OperarApi(HttpMethod metodo,string recurso,string jsonstring=null)
        {
            
                HttpRequestMessage requesting = new HttpRequestMessage(metodo, recurso);
                string obtener_token = HttpContext.Session.GetInt32(Autenticado) == 1? HttpContext.Session.GetString(Token):"";
                requesting.Headers.Add("Authorization", string.Concat("Bearer ", obtener_token.ToString().Replace('"', ' ').Trim()));
                requesting.Properties.Add("Encoding", "UTF-8");
                /*obtener el request local*/
                if (!string.IsNullOrEmpty(jsonstring))
                    requesting.Content = new StringContent(jsonstring.ToString().Replace('"', ' ').Trim(), Encoding.UTF8, "application/json");
                //if (archivo != null)
                //    requesting.Content = ManejarArchivos(archivo);
                try
                {
                    using (HttpResponseMessage response = await cliente.SendAsync(requesting))
                    {
                        string error = "OK";
                        bool satisfactorio = true;
                        string status = "";
                        if (response.StatusCode.ToString() != "OK")
                        {
                            error = string.Format("{0}: {1}", response.StatusCode, await response.Content.ReadAsStringAsync());
                            satisfactorio = false;
                            status = response.StatusCode.ToString();
                        }

                        if (response.StatusCode.ToString() == "Unauthorized")
                        {
                            status = response.StatusCode.ToString();
                        }

                        //cliente.Dispose();
                        return new ResponseApi()
                        {
                            Satisfactorio = satisfactorio,
                            Error = error,
                            ContenidofromJson = await response.Content.ReadAsStringAsync(),
                            ContenidoDeStream = await response.Content.ReadAsStreamAsync(),
                            Status = status
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseApi()
                    {
                        Satisfactorio = false,
                        Error = ex.Message,
                        ContenidofromJson = null
                    };
                }
        }


        

      
        /*termina la repetición*/
    }
}