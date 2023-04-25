using System;
using System.Collections.Generic;

namespace ProjectBorderland.DeveloperTools.PublishSubscribe
{
    /// <summary>
    /// Subscriber for Publish Subscribe design pattern.
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    public class Subscriber<TMessage> : ISubscribe
    {
        //==============================================================================
        // Variables
        //==============================================================================
        protected List<Action<TMessage>> subscribers = new List<Action<TMessage>>();



        //==============================================================================
        // Functions
        //==============================================================================
        /// <summary>
        /// Adds a subscriber to subscribers list.
        /// </summary>
        /// <param name="subscriber"></param>
        public void Add(Action<TMessage> subscriber)
        {
            subscribers.Add(subscriber);
        }



        /// <summary>
        /// Removes a subscriber from subscribers list.
        /// </summary>
        /// <param name="subscriber"></param>
        public void Remove(Action<TMessage> subscriber)
        {
            subscribers.Remove(subscriber);
        }



        /// <summary>
        /// Sends message to every subscriber in subscribers list.
        /// </summary>
        /// <param name="message"></param>
        public void SendMessage(TMessage message)
        {
            foreach (var subscriber in subscribers)
            {
                subscriber(message);
            }
        }
    }
}