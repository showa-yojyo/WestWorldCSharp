﻿// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

namespace WestWorld.FSM
{
    using Messaging;

    /// <summary>
    /// Interface to define an interface for a state.
    /// </summary>
    public interface IState<T>
    {
        /// <summary>
        /// This will execute when the state is entered.
        /// </summary>
        /// <param name="context"></param>
        void Enter(T context);

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="context"></param>
        void Execute(T context);

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="context"></param>
        void Exit(T context);

        /// <summary>
        /// This executes if the agent receives a message from the message dispatcher.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool OnMessage(T context, Telegram message);
    }
}
