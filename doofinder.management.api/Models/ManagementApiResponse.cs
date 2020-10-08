
using RestSharp;

namespace doofinder.management.api.Models
{
    public class ManagementApiResponse<T>
    {
        public IRestResponse HttpResponse { get; set; }

        public T Data { get; set; }
    }
}
