﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TipWallet.ViewModels;

namespace TipWallet
{
    public abstract class Bootstrapper
    {
        protected ContainerBuilder ContainerBuilder { get; set; }
        public Bootstrapper()
        {
            Initialize();
            FinishInitializing();
        }
        private void Initialize()
        {
            //var currentAssembly = Assembly.GetExecutingAssembly();
            ContainerBuilder = new ContainerBuilder();


            //Ine way of registering types
            //foreach (var type in currentAssembly.DefinedTypes
            //          .Where(e =>
            //                 e.IsSubclassOf(typeof(Page)) ||
            //                 e.IsSubclassOf(typeof(ViewModel))))
            //{
            //    ContainerBuilder.RegisterType(type.AsType());
            //}



            // Registers Types of Views and ViewModels
            var currentAssembly = Assembly.GetExecutingAssembly();

            currentAssembly.DefinedTypes
                .Where(type => type.IsClass)
                .Where(type => type.IsSubclassOf(typeof(ViewModel)) || type.Name.EndsWith("View"))
                .ToList()
                .ForEach(type => ContainerBuilder.RegisterType(type));
            // Singletons

        }
        private void FinishInitializing()
        {
            var container = ContainerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
