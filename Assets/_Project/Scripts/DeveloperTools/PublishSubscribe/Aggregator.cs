using System;
using System.Collections.Generic;

namespace ProjectBorderland.DeveloperTools.PublishSubscribe
{
    /// <summary>
    /// Aggregator for Publish Subscribe design pattern.
    /// </summary>
    public class Aggregator
    {
        //==============================================================================
        // Variables
        //==============================================================================
        protected Dictionary<Type, ISubscribe> subscribers = new Dictionary<Type, ISubscribe>();
        


        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Gets message identifier.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        protected virtual Type GetMessageIdentifier<TMessage>()
        {
            return typeof(TMessage);
        }



        /// <summary>
        /// Publish a message to subscribers.
        /// </summary>
        /// <param name="message"></param>
        /// <typeparam name="TMessage"></typeparam>
        public virtual void Publish<TMessage>(TMessage message)
        {
            var messageType = GetMessageIdentifier<TMessage>();

            if (subscribers.ContainsKey(messageType))
            {
                var subscriber = subscribers[messageType] as Subscriber<TMessage>;
                subscriber.SendMessage(message);
            }
        }



        /// <summary>
        /// Subscribes to a message.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <typeparam name="TMessage"></typeparam>
        public virtual void Subscribe<TMessage>(Action<TMessage> _subscriber)
        {
            var messageType = GetMessageIdentifier<TMessage>();

            if (!subscribers.ContainsKey(messageType))
            {
                subscribers.Add(messageType, new Subscriber<TMessage>());
            }

            var subscriber = subscribers[messageType] as Subscriber<TMessage>;
            subscriber.Add(_subscriber);
        }



        /// <summary>
        /// Unsubscribes all subscribers from all messages.
        /// </summary>
        public virtual void UnsubscribeAll()
        {
            subscribers.Clear();
        }



        /// <summary>
        /// Unsubscribes all subscribers with specified message.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        public virtual void UnsubscribeAll<TMessage>()
        {
            var messageType = GetMessageIdentifier<TMessage>();

            if (subscribers.ContainsKey(messageType))
            {
                subscribers.Remove(messageType);
            }
        }



        /// <summary>
        /// Unsubscribes to a specified message.
        /// </summary>
        /// <param name="subscriber"></param>
        /// <typeparam name="TMessage"></typeparam>
        public virtual void Unsubscribe<TMessage>(Action<TMessage> _subscriber)
        {
            var messageType = GetMessageIdentifier<TMessage>();

            if (subscribers.ContainsKey(messageType))
            {
                var subscriber = subscribers[messageType] as Subscriber<TMessage>;
                subscriber.Remove(_subscriber);
            }
        }
        #endregion
    }
}
