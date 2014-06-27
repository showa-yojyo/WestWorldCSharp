// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;
using System.Diagnostics;

namespace WestWorld
{
    using FSM;
    using Messaging;

    /// <summary>
    /// A class defining a goldminer.
    /// </summary>
    public class Miner : BaseGameEntity
    {
        /// <summary>
        /// the amount of gold a miner must have before he feels comfortable
        /// </summary>
        public static readonly int ComfortLevel = 5;

        /// <summary>
        /// the amount of nuggets a miner can carry
        /// </summary>
        public static readonly int MaxNuggets = 3;

        /// <summary>
        /// above this value a miner is thirsty
        /// </summary>
        public static readonly int ThirstLevel = 5;

        /// <summary>
        /// above this value a miner is sleepy
        /// </summary>
        public static readonly int TirednessThreshold = 5;

        /// <summary>
        /// An instance of the state machine class.
        /// </summary>
        public StateMachine<Miner> StateMachine { get; private set; }

        /// <summary>
        /// Where the miner is.
        /// </summary>
        public LocationType Location { get; set; }

        private int goldCarried;

        /// <summary>
        /// How many nuggets the miner has in his pockets.
        /// </summary>
        public int GoldCarried 
        {
            get
            {
                Debug.Assert(0 <= goldCarried);
                return goldCarried;
            }
            set
            {
                goldCarried = 0 < value ? value : 0;
                Debug.Assert(0 <= goldCarried);
            }
        }

        private int moneyInBank;

        /// <summary>
        /// MoneyInBank in the original code.
        /// </summary>
        public int Wealth 
        {
            get
            {
                Debug.Assert(0 <= moneyInBank);
                return moneyInBank;
            }
            set
            {
                moneyInBank = 0 < value ? value : 0;
                Debug.Assert(0 <= moneyInBank);
            }
        }

        /// <summary>
        /// The higher the value, the thirstier the miner
        /// </summary>
        private int Thirst { get; set; }

        /// <summary>
        /// The higher the value, the more tired the miner.
        /// </summary>
        private int Fatigue { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public Miner(EntityType id)
            : base(id)
        {
            Location = LocationType.Shack;

            StateMachine = new StateMachine<Miner>(this);
            StateMachine.CurrentState = GoHomeAndSleepTilRested.Instance;
        }

        /// <summary>
        /// This must be implemented.
        /// </summary>
        public override void Update()
        {
            ++Thirst;
            Console.ForegroundColor = ConsoleColor.Red;
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

        //public void AddToGoldCarried(int val)
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool PocketsFull()
        {
            return GoldCarried >= MaxNuggets;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Fatigued()
        {
            return Fatigue > TirednessThreshold;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DecreaseFatigue()
        {
            --Fatigue;
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncreaseFatigue()
        {
            ++Fatigue;
        }

        //public void AddToWealth(int val)
        
        /// <summary>
        /// 
        /// </summary>
        public bool Thirsty()
        {
            return Thirst >= ThirstLevel;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuyAndDrinkAWhiskey()
        {
            Thirst = 0;
            Wealth -= 2;
        }
    }
}
