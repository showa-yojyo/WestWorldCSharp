// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

namespace WestWorld
{
    using Messaging;

    /// <summary>
    /// Base class for a game object.
    /// </summary>
    public abstract class BaseGameEntity
    {
        /// <summary>
        /// Every entity must have a unique identifying number
        /// </summary>
        public EntityType ID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return ID.ToString();
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">A unique identifying number</param>
        public BaseGameEntity(EntityType id)
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
        public abstract bool HandleMessage(Telegram message);
    }
}
