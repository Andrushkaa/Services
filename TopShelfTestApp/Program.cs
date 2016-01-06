using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelfTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfig =>
            {
                hostConfig.Service<Service>(serviseConfig =>
                {
                    serviseConfig.ConstructUsing(() => new Service());
                    serviseConfig.WhenStarted(service => service.Start());
                    serviseConfig.WhenStopped(service => service.Stop());
                });
                hostConfig.RunAsLocalSystem();

                hostConfig.SetDisplayName("Service");
                hostConfig.SetDescription("Service using TopShelf");
                hostConfig.SetServiceName("Service");
            });
        }
    }
}
