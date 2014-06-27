// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// This is implemented as a state blip. The miner eats the stew, gives
    /// Elsa some compliments and then returns to his previous state
    /// </summary>
    public sealed class EatStew : IState<Miner>
    {
        private static readonly EatStew instance = new EatStew();

        private EatStew()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static EatStew Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// This will execute when the state is entered.
        /// </summary>
        /// <param name="miner"></param>
        public void Enter(Miner miner)
        {
            Console.WriteLine("{0}: Smells Reaaal goood Elsa!", miner.Name);
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        public void Execute(Miner miner)
        {
            Console.WriteLine("{0}: Tastes real good too!", miner.Name);
            miner.StateMachine.RevertToPreviousState();
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        public void Exit(Miner miner)
        {
            Console.WriteLine("{0}: Thankya li'lle lady. Ah better get back to whatever ah wuz doin'", miner.Name);
        }

        /// <summary>
        /// This executes if the agent receives a message from the message dispatcher.
        /// </summary>
        /// <param name="miner"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool OnMessage(Miner miner, Telegram message)
        {
            // Send message to global message handler
            return false;
        }
    }
}
