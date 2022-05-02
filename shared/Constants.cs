namespace shared
{
    using System;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    public class Constants
    {
        public string WalletEndpoint { get; set; }

        public string BlockchainEndpoint { get; set; }

        public string OpencloserEndpoint { get; set; }

        public string RegisterEndpoint { get; set; }


        public Constants()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings." + Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") + ".json", true, true);
            IConfiguration configuration = builder.Build();

            this.WalletEndpoint = configuration["WalletEndpoint"];
            this.BlockchainEndpoint = configuration["BlockchainEndpoint"];
            this.OpencloserEndpoint = configuration["OpencloserEndpoint"];
            this.RegisterEndpoint = configuration["RegisterEndpoint"];
        }
    }
}
