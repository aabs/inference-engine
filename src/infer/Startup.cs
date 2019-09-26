﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using VDS.RDF.Query;
using VDS.RDF.Update;
using static infer.Program;

namespace infer
{
    internal class Startup
    {
        public static IContainer Container { get; private set; }

        public static void Configure(Options opts)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<infer_core.InferenceEngine>().AsImplementedInterfaces();
            Console.WriteLine($"SPARQL Endpoint: {opts.Endpoint}");
            builder.Register<ISparqlQueryProcessor>(ctx => new RemoteQueryProcessor(new SparqlRemoteEndpoint(opts.Endpoint)));
            builder.Register<ISparqlUpdateProcessor>(ctx => new RemoteUpdateProcessor(new SparqlRemoteUpdateEndpoint(opts.Endpoint)));

            //// Register individual components
            //builder.RegisterInstance(new TaskRepository())
            //       .As<ITaskRepository>();
            //builder.RegisterType<TaskController>();
            //builder.Register(c => new LogManager(DateTime.Now))
            //       .As<ILogger>();

            //// Scan an assembly for components
            //builder.RegisterAssemblyTypes(myAssembly)
            //       .Where(t => t.Name.EndsWith("Repository"))
            //       .AsImplementedInterfaces();

            Container = builder.Build();
        }
    }
}
