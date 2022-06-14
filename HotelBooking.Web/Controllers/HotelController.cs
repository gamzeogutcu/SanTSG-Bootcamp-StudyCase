using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Identity.Client;
using HotelBooking.Web.Services;
using HotelBooking.Web.Models.Response.Authentication;

namespace HotelBooking.Web.Controllers
{
    public class HotelController : Controller
    {
        /*private readonly IHttpClientFactory _httpClientFactory;

        public HotelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }*/
        public string CreateToken()
        {
            Models.Request.Authentication.LoginRequest request = new Models.Request.Authentication.LoginRequest();
            request.Agency = "PXM25397";
            request.User = "USR1";
            request.Password = "test!23";
            _ = HotelService.Post<LoginResponse>("http://service.stage.paximum.com/v2/api/authenticationservice/login", request);
            return LoginResponse.Body.token;
        }
                /*
            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
            /*public async Task<IActionResult> Index()
            {

                List<Hotel> hotel = new List<Hotel>();

                var httpClient = _httpClientFactory.CreateClient();
                var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJVaWQiOiIzOTYxMCIsIkRCIjoiVE9VUlZJU0lPIiwiV0lkIjoiMSIsIldtSWQiOiIxIiwiQUciOiJQWE0yNTM5NyIsIkFOYW1lIjoiVGVzdCBCdXllciIsIk1SIjoiUEFYSU1VTSIsIk9GIjoiUFhNNTE0IiwiT0ZOYW1lIjoiVGVzdCBCdXllciIsIk9QIjoiUEFYSU1VTSIsIlVTIjoiVVNSMSIsIkFUIjoiMCIsIldUIjoiMSIsIlNQIjoiMCIsIlBGIjoiMCIsIlBUIjpbIjIiLCIzIiwiMiwzIiwiNSIsIjQiLCIxNCIsIjEiXSwiVFQiOiIxIiwiVVJvbGUiOlsiNiIsIjciLCI4Il0sIlRpZCI6IjUxMDM1NzAiLCJuYmYiOjE2NTUxOTI4MzQsImV4cCI6MTY1NTIyODgzNCwiaWF0IjoxNjU1MTkyODM0fQ.zZmLtwFZUvY8WLRKPFuaRfeTdi4NeDBY9ohJVeOPztw";
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await httpClient.GetAsync("http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete");

                if (response.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var HotelResponse = response.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the hotel list
                     hotel = JsonConvert.DeserializeObject<List<Hotel>>(HotelResponse);
                }
                //returning the hotel list to view
                return View(hotel);

            }
                *//*
            public async Task<IActionResult> Index()
            {
                var hotel = await GetHotels();
                return View(hotel);
            }

            [HttpGet]
            public async Task<List<Hotel>> GetHotels()
            {
                //to get token
                var scopes = new[] { $"api/authenticationservice/login" };
                var accessToken = await tokenAcquisition.*//*
                //var result = await confidentialClient.AcquireToken(scopes).ExecuteAsync();
                //var accessToken = HttpContext.Session.GetString("JWToken");

                    //HttpContext.Session.GetString("JWToken");
                    //use the access token to call protected web API

                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                string jsonStr = await client.GetStringAsync("http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete");
                var res = JsonConvert.DeserializeObject<List<Hotel>>(jsonStr).ToList();
                return res;



            }

        }*/
    }
    }