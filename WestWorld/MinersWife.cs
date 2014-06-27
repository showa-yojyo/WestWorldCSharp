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
    public class MinersWife : BaseGameEntity
    {
        /// <summary>
        /// An instance of the state machine class.
        /// </summary>
        public StateMachine<MinersWife> StateMachine { get; private set; }

        /// <summary>
        /// Where the miner is.
        /// </summary>
        public LocationType Location { get; set; }

        /// <summary>
        /// Is she presently cooking?
        /// </summary>
        public bool Cooking { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public MinersWife(EntityType id)
            : base(id)
        {
            Location = LocationType.Shack;

            StateMachine = new StateMachine<MinersWife>(this);
            StateMachine.CurrentState = DoHouseWork.Instance;
            StateMachine.GlobalState = WifesGlobalState.Instance;
        }

        /// <summary>
        /// This must be implemented.
        /// </summary>
        public override void Update()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            StateMachine.Update();
        }

        /// <summary>
        /// All entities can communicate using messages. They are sent
        /// using the MessageDispatcher singleton class
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public override bool HandleMessage(Telegram message)
        {
            return StateMachine.HandleMessage(message);
        }
    }
}
