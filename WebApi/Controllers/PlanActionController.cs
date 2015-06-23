using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class PlanActionController : ApiController
    {
        private readonly IPlanActionStore _planActionStore;
        private readonly IRituelStore _rituelStore;

        public PlanActionController(IPlanActionStore planActionStore, IRituelStore rituelStore)
        {
            _planActionStore = planActionStore;
            _rituelStore = rituelStore;
        }

        public HttpResponseMessage Post(PlanAction planAction)
        {
            var rituel = _rituelStore.Get(planAction.Rituel);
            if (rituel == null) return new HttpResponseMessage(HttpStatusCode.NotFound);
            planAction.Date = rituel.Date;
            _planActionStore.Register(planAction);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public PlanAction Get(string nomRituel, DateTime jour)
        {
            return _planActionStore.Get(nomRituel, jour);
        }
    }
}