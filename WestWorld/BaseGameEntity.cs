// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System.Diagnostics;

namespace WestWorld
{
    /// <summary>
    /// Base class for a game object.
    /// </summary>
    public abstract class BaseGameEntity
    {
        private int id;

        /// <summary>
        /// Every entity must have a unique identifying number
        /// </summary>
        /// <remarks>
        /// The setter must be called within each constructor to make sure the ID is set
        /// correctly. It verifies that the value passed to the method is greater
        /// or equal to the next valid ID, before setting the ID and incrementing
        /// the next valid ID
        /// </remarks>
        public int ID
        {
            get
            {
                return id;
            }

            // make sure the val is equal to or greater than the next available ID
            private set
            {
                Debug.Assert(value >= NextValidID, "<BaseGameEntity::SetID>: invalid ID");
                id = value;
                NextValidID = value + 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return ((EntityType)ID).ToString();
            }
        }

        /// <summary>
        /// This is the next valid ID.
        /// </summary>
        /// <remarks>
        /// Each time a BaseGameEntity is instantiated this value is updated.
        /// </remarks>
        static private int NextValidID
        {
            get;
            set;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">A unique identifying number</param>
        public BaseGameEntity(int id)
        {
            ID = id;
        }

        /// <summary>
        /// All entities must implement an update function.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// All entities can communicate using messages. They are sent
        /// using the MessageDispatcher singleton class
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public abstract bool HandleMessage(Messaging.Telegram message);
    }
}
