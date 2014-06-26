// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// Entity will go to a bank and deposit any nuggets he is carrying.
    /// </summary>
    /// <remarks>
    /// If the miner is subsequently wealthy enough he'll walk home, otherwise he'll
    /// keep going to get more gold.
    /// </remarks>
    public sealed class VisitBankAndDepositGold : IState<Miner>
    {
        private static readonly VisitBankAndDepositGold instance = new VisitBankAndDepositGold();

        private VisitBankAndDepositGold()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static VisitBankAndDepositGold Instance
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
            // On entry the miner makes sure he is located at the bank.
            if(miner.Location != LocationType.Bank)
            {
                Console.WriteLine("{0}: Goin' to the bank. Yes siree", miner.Name);
                miner.Location = LocationType.Bank;
            }
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        public void Execute(Miner miner)
        {
            // Deposit the gold.
            miner.Wealth += miner.GoldCarried;
            miner.GoldCarried = 0;

            Console.WriteLine("{0}: Depositing gold. Total savings now: {1}", miner.Name, miner.Wealth);
            
            // Wealthy enough to have a well earned rest?
            if(miner.Wealth >= Miner.ComfortLevel)
            {
                Console.WriteLine("{0}: WooHoo! Rich enough for now. Back home to mah li'lle lady", miner.Name);

                miner.StateMachine.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            // Otherwise get more gold.
            else 
            {
                miner.StateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        public void Exit(Miner miner)
        {
            Console.WriteLine("{0}: Leavin' the bank", miner.Name);
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
