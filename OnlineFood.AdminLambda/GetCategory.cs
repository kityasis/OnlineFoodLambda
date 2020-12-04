using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using OnlineFood.Database;
using OnlineFood.Infrastructure.Services;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace OnlineFood.AdminLambda
{
    public class GetCategoryFunction
    {
        
        public APIGatewayProxyResponse GetCategory(APIGatewayProxyRequest request)
        {
            if(request.PathParameters!=null&&request.PathParameters.ContainsKey("categoryId")
                && int.TryParse(request.PathParameters["categoryId"],out var categoryId))
            {
                var onlineFoodContext = new OnlineFoodContext();
                var categoryService = new CategoryService(onlineFoodContext);
                var getCategory = categoryService.GetCategory(categoryId);
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    Body =JsonConvert.SerializeObject(getCategory)
                };

            }
            
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.NotFound
            };
        }
    }
}
