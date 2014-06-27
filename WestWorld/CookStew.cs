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
    public sealed class CookStew : IState<MinersWife>
    {
        private static readonly CookStew instance = new CookStew();

        private CookStew()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static CookStew Instance
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
            // If not already cooking put the stew in the oven.
            if(!wife.Cooking)
            {
                Console.WriteLine("{0}: Putting the stew in the oven", wife.Name);

                // Send a delayed message myself so that I know when to take the stew
                // out of the oven.
                MessageDispatcher.Instance.DispatchMessage(
                    1.5, // time delay
                    wife.ID, // sender ID
                    wife.ID, // receiver ID
                    MessageType.StewReady, // msg
                    MessageDispatcher.NO_ADDITIONAL_INFO);

                wife.Cooking = true;
            }
        }

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="wife"></param>
        public void Execute(MinersWife wife)
        {
            Console.WriteLine("{0}: Fussin' over food", wife.Name);
        }

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="wife"></param>
        public void Exit(MinersWife wife)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Puttin' the stew on the table", wife.Name);
        }

        /// <summary>
        /// This executes if the agent receives a message from the message dispatcher.
        /// </summary>
        /// <param name="wife"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool OnMessage(MinersWife wife, Telegram message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Console.BackgroundColor = ConsoleColor.Red;

            switch(message.Message)
            {
            case MessageType.StewReady:
                Console.WriteLine("Message received by {0} at time: {1}", wife.Name, 1e-3 * Environment.TickCount);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}: StewReady! Lets eat", wife.Name);

                // Let hubby know the stew is ready
                MessageDispatcher.Instance.DispatchMessage(
                    MessageDispatcher.SEND_MSG_IMMEDIATELY,
                    wife.ID,
                    EntityType.Bob,
                    MessageType.StewReady,
                    MessageDispatcher.NO_ADDITIONAL_INFO);

                wife.Cooking = false;

                wife.StateMachine.ChangeState(DoHouseWork.Instance);

                return true;
            } // end switch

            return false;
        }
    }
}
