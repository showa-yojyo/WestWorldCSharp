﻿// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// A miner will go home and sleep until his fatigue is decreased
    //  sufficiently.
    /// </summary>
    public sealed class GoHomeAndSleepTilRested : IState<Miner>
    {
        private static readonly GoHomeAndSleepTilRested instance = new GoHomeAndSleepTilRested();

        private GoHomeAndSleepTilRested()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static GoHomeAndSleepTilRested Instance
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
            if(miner.Location != LocationType.Shack)
            {
                Console.WriteLine("{0}: Walkin' home", miner.Name);
                miner.Location = LocationType.Shack;

                // Let the wife know I'm home.
                MessageDispatcher.Instance.DispatchMessage(
                    MessageDispatcher.SEND_MSG_IMMEDIATELY, // time delay
                    miner.ID, // ID of sender
                    EntityType.Elsa, // ID of recipient
                    MessageType.HiHoneyImHome, // the message
                    MessageDispatcher.NO_ADDITIONAL_INFO);    
            }
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        public void Execute(Miner miner)
        {
            // If miner is not fatigued start to dig for nuggets again.
            if(!miner.Fatigued())
            {
                Console.WriteLine("{0}: What a God darn fantastic nap! Time to find more gold", miner.Name);
                miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                // Sleep.
                miner.DecreaseFatigue();

                Console.WriteLine("{0}: ZZZZ...", miner.Name);
            }
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        public void Exit(Miner miner)
        {
            Console.WriteLine("{0}: Leaving the house", miner.Name);
        }

        /// <summary>
        /// This executes if the agent receives a message from the message dispatcher.
        /// </summary>
        /// <param name="miner"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool OnMessage(Miner miner, Telegram message)
        {
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;

            switch(message.Message)
            {
            case MessageType.StewReady:
                Console.WriteLine("Message handled by {0} at time: {1}", miner.Name, 1e-3 * Environment.TickCount);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}: Okay Hun, ahm a comin'!", miner.Name);
                miner.StateMachine.ChangeState(EatStew.Instance);
                return true;
            } // end switch

            // Send message to global message handler
            return false;
        }
    }
}
