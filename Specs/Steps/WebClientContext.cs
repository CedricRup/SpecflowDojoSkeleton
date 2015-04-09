
using System;
using ApiClient;

namespace Specs.Steps
{
    public class WebClientContext
    {
        public WebClientContext()
        {
            WebClient = new V1Client(new Uri("http://localhost:12345/api"));
        }

        public V1Client WebClient { get; private set; }
    }
}
