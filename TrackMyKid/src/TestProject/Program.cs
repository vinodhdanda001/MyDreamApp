using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMyKid.Common;
using TrackMyKid.Common.Models;
using TrackMyKid.DataLayer;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TestProject
{
    class Program
    {
        private static readonly log4net.ILog log = //LogHelper.GetLogger();
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            testLogin();
        }

        static void testLogin()
        {

            log.Debug("Developer : Debugging each event");
            LoginDataService loginDataService = new LoginDataService();
            LoginModel loginModel = new LoginModel
            {
                userName = "9100000101",
                organizationId = 100
            };
            var x= loginDataService.Login(loginModel);
            Console.ReadLine();
        }




    }

    //class Program
    //{
    //    private static readonly log4net.ILog log = //LogHelper.GetLogger();
    //        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    //    static void Main(string[] args)
    //    {
    //        log.Debug("Developer : Debugging each event");
    //        log.Info("Maintenance : The site is going under maintannnce");
    //        log.Warn("Maintenance : So Many issues to taccle. will take some time");
    //        var i = 0;

    //        try
    //        {
    //            var j = 5 / i;
    //        }
    //        catch(DivideByZeroException ex)
    //        {
    //            log.Error("Developer : Devide by Zero", ex);
    //        }

    //        log.Fatal("Maintenance : Site is break down.");
    //        Console.ReadLine();

    //    }
    //}
}
