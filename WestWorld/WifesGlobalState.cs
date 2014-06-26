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
    public class WifesGlobalState : IState<MinersWife>
    {
        private static readonly WifesGlobalState instance = new WifesGlobalState();

        private WifesGlobalState()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static WifesGlobalState Instance
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
            // 1 in 10 chance of needing the bathroom.
            var rand = new Random();
            if(rand.Next(10) == 0)
            {
                wife.StateMachine.ChangeState(VisitBathroom.Instance);
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
            return true;
        }
    }
}
