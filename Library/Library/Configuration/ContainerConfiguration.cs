﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Library.Repository;
using Library.Repository.Interface;
using Library.Serializer;
using Library.Service.TehnicalService;
using Library.Core.TehnicalService.Interface;
using Library.Core.Model;
using Library.Core.Repository;
using Library.Core.Repository.Interface;

namespace Library.Configuration
{
    public static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ResourceConfigurationJSON<User>>().As<IResourceConfiguration<User>>();
            builder.RegisterType<SerializerJSON<User>>().As<ISerializer<User>>();
            builder.RegisterType<CRUDRepository<User>>().As<ICRUDRepository<User>>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            
            
            
            
            builder.RegisterType<LoginService>().As<ILoginService>();

            return builder.Build();
        }
    }
}
