﻿using System;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;
using SM.Configuration.Configuration;
using SM.Core.Services;

namespace SM.API.Service
{
    public class ApiServiceHost : SMServiceHost
    {
        IDisposable _server;

        public override void OnStartUp()
        {
            Console.ForegroundColor = ConsoleColor.White;            
            var baseAddress = string.Format("{0}:{1}", SMConfigurations.Current.ApiConfiguration.URL, SMConfigurations.Current.ApiConfiguration.PortNumber);
            _server = WebApp.Start<Startup>(baseAddress);

            WriteInfo(string.Format("API is started, and listening on: {0}", baseAddress));
        }

        public override void OnStop()
        {
            _server.Dispose();
        }
    }
}