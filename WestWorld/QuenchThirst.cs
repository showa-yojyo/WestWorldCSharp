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
    /// TODO
    /// </summary>
    public sealed class QuenchThirst : IState
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
