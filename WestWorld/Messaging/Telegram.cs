// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

namespace WestWorld.Messaging
{
    /// <summary>
    /// This defines a telegram. A telegram is a data structure that
    /// records information required to dispatch messages. Messages 
    /// are used by game agents to communicate with each other.
    /// </summary>
    public class Telegram// : System.Object
    {
        /// <summary>
        /// The entity that sent this telegram.
        /// </summary>
        public EntityType Sender { get; set; }

        /// <summary>
        /// The entity that is to receive this telegram.
        /// </summary>
        public EntityType Receiver { get; set; }

        /// <summary>
        /// The message itself.
        /// </summary>
        public MessageType Message { get; set; }

        /// <summary>
        /// Messages can be dispatched immediately or delayed for a specified amount
        /// of time. If a delay is necessary this field is stamped with the time 
        /// the message should be dispatched.
        /// </summary>
        /// <remarks>In seconds (not miliseconds)</remarks>
        public double DispatchTime { get; set; }

        /// <summary>
        /// Any additional information that may accompany the message.
        /// </summary>
        public object ExtraInfo { get; set; }

        /// <summary>
        /// The default constructor
        /// </summary>
        public Telegram()
            : this(-1.0, EntityType.None, EntityType.None, MessageType.None, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <param name="info"></param>
        public Telegram(
            double time,
            EntityType sender,
            EntityType receiver,
            MessageType message,
            object info = null)
        {
            DispatchTime = time;
            Sender = sender;
            Receiver = receiver;
            Message = message;
            ExtraInfo = info;
        }
    }
}
