// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;

namespace WestWorld
{
    /// <summary>
    /// 
    /// </summary>
    public class VisitBathroom : IState<MinersWife>
    {
        private static readonly VisitBathroom instance = new VisitBathroom();

        private VisitBathroom()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static VisitBathroom Instance
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
            Console.WriteLine("{0} : Walkin' to the can. Need to powda mah pretty li'lle nose", wife.Name);
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="wife"></param>
        public void Execute(MinersWife wife)
        {
            Console.WriteLine("{0} : Ahhhhhh! Sweet relief!", wife.Name);
            wife.StateMachine.RevertToPreviousState();
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="wife"></param>
        public void Exit(MinersWife wife)
        {
            Console.WriteLine("{0} : Leavin' the Jon", wife.Name);
        }

        /// <summary>
        /// This executes if the agent receives a message from the message dispatcher.
        /// </summary>
        /// <param name="wife"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool OnMessage(MinersWife wife, Messaging.Telegram message)
        {
            return true;
        }
    }
}
