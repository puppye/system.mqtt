using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace System.Protos.Services
{
    public class PostService : WeatherForecasts.WeatherForecastsBase
    {
        public PostService()
        {

        }

        public override Task<GetWeatherForecastsResponse> GetWeatherForecasts(Empty request, ServerCallContext context)
        {


            return base.GetWeatherForecasts(request, context);
        }

        public override Task<Empty> WeatherPost(WeatherForecastPostRequest request, ServerCallContext context)
        {


            return base.WeatherPost(request, context);
        }
    }
}
