using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;

namespace QuickstartIdentityServer.Quickstart
{
    public class ClientController : Controller
    {
        private readonly IClientStore _clientStore;
        public ClientController(IClientStore clientStore)
        {
            _clientStore = clientStore;
        }
        public IActionResult Index()
        {
            return Content(_clientStore.GetType().FullName);
        }
    }
}