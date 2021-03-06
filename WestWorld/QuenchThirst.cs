﻿// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// TODO
    /// </summary>
    public sealed class QuenchThirst : IState<Miner>
    {
        private static readonly QuenchThirst instance = new QuenchThirst();

        private QuenchThirst()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static QuenchThirst Instance
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
            if(miner.Location != LocationType.Saloon)
            {
                Console.WriteLine("{0}: Boy, ah sure is thusty! Walking to the saloon", miner.Name);
                miner.Location = LocationType.Saloon;
            }
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        public void Execute(Miner miner)
        {
            if(miner.Thirsty())
            {
                miner.BuyAndDrinkAWhiskey();
                Console.WriteLine("{0}: That's mighty fine sippin liquer", miner.Name);

                miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                Console.WriteLine("ERROR! ERROR! ERROR!");
            }
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        public void Exit(Miner miner)
        {
            Console.WriteLine("{0}: Leaving the saloon, feelin' good", miner.Name);
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
