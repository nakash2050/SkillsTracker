using AutoMapper;
using SkillsTracker.API.App_Start;
using System.Web.Http;

namespace SkillsTracker.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(config => config.AddProfile<MappingProfile>());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
