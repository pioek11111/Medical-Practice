﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using System.Linq;
using Moq;
using MedicalPractice.Domain.Abstract;
using MedicalPractice.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IDoctorsRepository>().To<EFDoctorRepository>();
            //Mock<IDoctorsRepository> mock = new Mock<IDoctorsRepository>();
            //mock.Setup(m => m.repository).Returns(new List<Doctor> {
            //    new Doctor { Name = "Piłka nożna", Surname = "gtew", Specjalization = "gtrwg" }
            //});
            //kernel.Bind<IDoctorsRepository>().ToConstant(mock.Object);
        }
    }
}