using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using System.Linq;
using Moq;
using MedicalPractice.Domain.Abstract;
using MedicalPractice.Domain.Entities;

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
            Mock<IDoctorsRepository> mock = new Mock<IDoctorsRepository>();
            mock.Setup(m => m.repository).Returns(new List<Doctor> {
                new Doctor { Name = "Agata", Surname = "Domańska-Niedziela", Specjalization = "Lekarz medycyny rodzinnej, pediatra" },
                new Doctor { Name = "Ewa", Surname = "Scibiór-Gryciuk", Specjalization = "Lekarz medycyny rodzinnej, internista" },
                new Doctor { Name = "Marzena", Surname = "Kamola", Specjalization = "Lekarz medycyny rodzinnej, internista" }

                });
            kernel.Bind<IDoctorsRepository>().ToConstant(mock.Object);
        }
    }
}