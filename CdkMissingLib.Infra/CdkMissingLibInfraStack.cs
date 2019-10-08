using System.IO;
using Amazon.CDK;
using Amazon.CDK.AWS.APIGateway;
using Amazon.CDK.AWS.Lambda;
using CdkMissingLib;


namespace CdkMissingLib.Infra
{
    public class CdkMissingLibInfraStack : Stack
    {
        public CdkMissingLibInfraStack(Construct parent, string id, IStackProps props) : base(parent, id, props)
        {


            var lambdaFunction = new Function(this, "webapi-function",
                new FunctionProps
                {
                    Code = Code.FromAsset(@"C:\Users\joanv\Source\Repos\CdkMissingLib\CdkMissingLib\bin\Debug\netcoreapp2.1"),
                    Handler = "CdkMissingLib::CdkMissingLib.LambdaEntryPoint::FunctionHandlerAsync",
                    Runtime = Runtime.DOTNET_CORE_2_1,
                    Timeout = Duration.Seconds(30),
                    MemorySize = 128
                }
            );

            var api = new LambdaRestApi(this, "webapi-function-api", new LambdaRestApiProps
            {
                Handler = lambdaFunction
            });

        }
    }
}
