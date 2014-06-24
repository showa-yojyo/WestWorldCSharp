// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld
{
    /// <summary>
    /// In this state the miner will walk to a goldmine and pick up a nugget
    /// of gold.
    /// </summary>
    /// <remarks>
    /// If the miner already has a nugget of gold he'll change state
    /// to VisitBankAndDepositGold. If he gets thirsty he'll change state
    /// to QuenchThirst.
    /// </remarks>
    public sealed class EnterMineAndDigForNugget : IState
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
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        public void Execute(Miner miner)
        {
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        public void Exit(Miner miner)
        {
        }
    }
}
