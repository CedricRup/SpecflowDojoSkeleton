using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class DailyController : ApiController
    {
        private readonly IDailyStore _dailyStore;
        private readonly IProjetStore _projectStore;

        public DailyController(IDailyStore dailyStore, IProjetStore projectStore)
        {
            _dailyStore = dailyStore;
            _projectStore = projectStore;
        }

        public HttpResponseMessage Post(Daily daily)
        {
            var project = _projectStore.Get(daily.Projet);
            if (project == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            daily.Date = project.Date;
            _dailyStore.Register(daily);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public Daily Get(string nomProjet, DateTime jour)
        {
            return _dailyStore.Get(nomProjet, jour);
        }
    }
}