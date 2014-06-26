// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
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
        public bool OnMessage(Miner miner, Messaging.Telegram message)
        {
            return true;
        }
    }
}
