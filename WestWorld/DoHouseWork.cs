// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// 
    /// </summary>
    public class DoHouseWork : IState<MinersWife>
    {
        private static readonly DoHouseWork instance = new DoHouseWork();

        private DoHouseWork()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static DoHouseWork Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// This will execute when the state is entered.
        /// </summary>
        /// <param name="wife"></param>
        public void Enter(MinersWife wife)
        {
            // NOP
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="wife"></param>
        public void Execute(MinersWife wife)
        {
            var rand = new Random(Environment.TickCount);
            switch(rand.Next(3))
            {
            case 0:
                Console.WriteLine("{0}: Moppin' the floor", wife.Name);
                break;
            case 1:
                Console.WriteLine("{0}: Washin' the dishes", wife.Name);
                break;
            case 2:
                Console.WriteLine("{0}: Makin' the bed", wife.Name);
                break;
            }
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="wife"></param>
        public void Exit(MinersWife wife)
        {
            // NOP
        }

        /// <summary>
        /// This executes if the agent receives a message from the message dispatcher.
        /// </summary>
        /// <param name="wife"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool OnMessage(MinersWife wife, Telegram message)
        {
            return false;
        }
    }
}
