using Amazon.CDK;

namespace CdkMissingLib.Infra
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App(null);

            new CdkMissingLibInfraStack(app, "CdkMissingLibInfraStack", new StackProps
            {
                Env = new Environment()
                {
                    Region = "eu-west-1",
                    Account = "084386761492"
                }

            });

            app.Synth();
        }
    }
}
