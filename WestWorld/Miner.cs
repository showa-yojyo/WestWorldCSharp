// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System.Diagnostics;

namespace WestWorld
{
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
        /// TODO
        /// </summary>
        private IState<Miner> CurrentState { get; set; }

        /// <summary>
        /// 
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
        public Miner(int id)
            : base(id)
        {
            Location = LocationType.Shack;
            CurrentState = GoHomeAndSleepTilRested.Instance;
        }

        /// <summary>
        /// This must be implemented.
        /// </summary>
        public override void Update()
        {
            ++Thirst;

            if(CurrentState != null)
            {
                CurrentState.Execute(this);
            }
        }

        /// <summary>
        /// This method changes the current state to the new state.
        /// </summary>
        /// <param name="state"></param>
        /// <remarks>
        ///  It first calls the Exit() method of the current state, then assigns the
        ///  new state to CurrentState and finally calls the Entry()
        ///  method of the new state.
        ///</remarks>
        public void ChangeState(IState<Miner> state)
        {
            // make sure both states are both valid before attempting to 
            // call their methods
            Debug.Assert(CurrentState != null);
            Debug.Assert(state != null);

            // call the exit method of the existing state
            CurrentState.Exit(this);

            // change state to the new state
            CurrentState = state;

            // call the entry method of the new state
            CurrentState.Enter(this);
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
