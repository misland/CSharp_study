using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;

namespace EF.Infrastruct
{
    public class NinjectFactory:DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IStudentRepository>().To<StudentRepository>();
            ninjectKernel.Bind<ICourseRepository>().To<CourseRepository>();
            ninjectKernel.Bind<ITripRepository>().To<TripRepository>();
            ninjectKernel.Bind<IActivityRepository>().To<ActivityRepository>();
        }
    }
}