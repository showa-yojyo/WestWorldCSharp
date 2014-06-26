// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestWorld.Messaging
{
    using Game;

    /// <summary>
    /// A message dispatcher. Manages messages of the type Telegram.
    /// Instantiated as a singleton.
    /// </summary>
    public class MessageDispatcher
    {
        public static readonly double SEND_MSG_IMMEDIATELY = 0.0;
        public static readonly int NO_ADDITIONAL_INFO = 0;
        public static readonly int SENDER_ID_IRRELEVANT = -1;

        /// <summary>
        /// A XXX is used as the container for the delayed messages
        /// because of the benefit of automatic sorting and avoidance
        /// of duplicates. Messages are sorted by their dispatch time.
        /// </summary>
        private ISet<Telegram> PriorityQ = new HashSet<Telegram>();

        private static readonly MessageDispatcher instance = new MessageDispatcher();

        private MessageDispatcher()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static MessageDispatcher Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Send a message to another agent. Receiving agent is referenced by ID.
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="msg"></param>
        /// <param name="info"></param>
        public void DispatchMessage(
            double delay,
            int sender,
            int receiver,
            int msg,
            object info)
        {
            // Get to the receiver
            var recieverEnt = EntityManager.Instance.GetEntityFromID(receiver);

            // Make sure the receiver is valid
            if(recieverEnt == null)
            {
                Debug.Assert(recieverEnt != null, string.Format("Warning! No Receiver with ID of {0} found", receiver));
                return;
            }

            // Create the telegram
            var telegram = new Telegram(0, sender, receiver, msg, info);

            // If there is no delay, route telegram immediately.                    
            if(delay <= 0.0)
            {
                //debug_con << "\nTelegram dispatched at time: " << TickCounter->GetCurrentFrame()
                //     << " by " << sender << " for " << receiver 
                //     << ". Msg is " << msg << "";

                // Send the telegram to the recipient
                Discharge(recieverEnt, telegram);
            }
            //else calculate the time when the telegram should be dispatched
            else
            {
                double CurrentTime = 0.0; // TODO: TickCounter->GetCurrentFrame();

                telegram.DispatchTime = CurrentTime + delay;

                // And put it in the queue
                PriorityQ.Add(telegram);

                //#ifdef SHOW_MESSAGING_INFO
                //debug_con << "\nDelayed telegram from " << sender << " recorded at time " 
                //        << TickCounter->GetCurrentFrame() << " for " << receiver
                //        << ". Msg is " << msg << "";
                //#endif
            }
        }

        /// <summary>
        /// Send out any delayed messages. This method is called each time through   
        /// the main game loop.
        /// </summary>
        public void DispatchDelayedMessages()
        {
            // First get current time
            double CurrentTime = 0.0; // TODO: TickCounter->GetCurrentFrame();

            var mgr = EntityManager.Instance;

            // Now peek at the queue to see if any telegrams need dispatching.
            // Remove all telegrams from the front of the queue that have gone
            // past their sell by date.
            while(PriorityQ.Any() &&
                   (PriorityQ.Min().DispatchTime < CurrentTime) &&
                   (PriorityQ.Min().DispatchTime > 0))
            {
                // Read the telegram from the front of the queue.
                var telegram = PriorityQ.Min();

                // Find the recipient.
                var receiver = mgr.GetEntityFromID(telegram.Receiver);

                //#ifdef SHOW_MESSAGING_INFO
                //debug_con << "\nQueued telegram ready for dispatch: Sent to " 
                //     << pReceiver->ID() << ". Msg is "<< telegram.Msg << "";
                //#endif

                // Send the telegram to the recipient
                Discharge(receiver, telegram);

                // Remove it from the queue.
                PriorityQ.Remove(telegram);
            }
        }

        /// <summary>
        /// This method is utilized by DispatchMessage or DispatchDelayedMessages.
        /// This method calls the message handling member function of the receiving
        /// entity, pReceiver, with the newly created telegram
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        private void Discharge(BaseGameEntity receiver, Telegram message)
        {
            if(!receiver.HandleMessage(message))
            {
                // TODO: debug write
            }
        }
    }
}
