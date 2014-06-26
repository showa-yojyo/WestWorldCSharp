// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// In this state the miner will walk to a goldmine and pick up a nugget
    /// of gold.
    /// </summary>
    /// <remarks>
    /// If the miner already has a nugget of gold he'll change state
    /// to VisitBankAndDepositGold. If he gets thirsty he'll change state
    /// to QuenchThirst.
    /// </remarks>
    public sealed class EnterMineAndDigForNugget : IState<Miner>
    {
        private static readonly EnterMineAndDigForNugget instance = new EnterMineAndDigForNugget();

        private EnterMineAndDigForNugget()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static EnterMineAndDigForNugget Instance
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
            // If the miner is not already located at the goldmine, he must
            // change location to the gold mine
            if(miner.Location != LocationType.Goldmine)
            {
                Console.WriteLine("{0}: Walkin' to the goldmine", miner.Name);

                miner.Location = LocationType.Goldmine;
            }
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        public void Execute(Miner miner)
        {
            // The miner digs for gold until he is carrying in excess of MaxNuggets. 
            // If he gets thirsty during his digging he packs up work for a while and 
            // changes state to go to the saloon for a whiskey.
            ++miner.GoldCarried;

            miner.IncreaseFatigue();

            Console.WriteLine("{0}: Pickin' up a nugget", miner.Name);

            // If enough gold mined, go and put it in the bank.
            if(miner.PocketsFull())
            {
                miner.StateMachine.ChangeState(VisitBankAndDepositGold.Instance);
            }

            if(miner.Thirsty())
            {
                miner.StateMachine.ChangeState(QuenchThirst.Instance);
            }
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        public void Exit(Miner miner)
        {
            Console.WriteLine("{0}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold", miner.Name);
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
