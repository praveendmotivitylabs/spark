﻿using Spark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spark.Service
{
    public interface IServiceListener
    {
        void Inform(Interaction interaction);
    }


    public class ServiceListener : IServiceListener
    {
        List<IServiceListener> listeners;

        public ServiceListener()
        {
            listeners = new List<IServiceListener>();
        }

        public void Add(IServiceListener listener)
        {
            this.listeners.Add(listener);
        }

        private async Task Inform(IServiceListener listener, Interaction interaction)
        {
            try
            {
                await Task.Run(() => 
                {
                    listener.Inform(interaction);
                });
            }
            catch
            {
                // Ingore errors coming from a listener. We might log it later.
            }
        }

        public async void Inform(Interaction interaction)
        {
            foreach(IServiceListener listener in listeners)
            {
                await Inform(listener, interaction);
            }
        }
    }
}
