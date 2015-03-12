using System.Linq;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class DummyController : ApiController
    {
        private readonly DummyStore _dummyStore;

        public DummyController(DummyStore dummyStore)
        {
            _dummyStore = dummyStore;
        }

        public Dummy Get()
        {
            return _dummyStore.GetAll().First();
        }
    }
}
