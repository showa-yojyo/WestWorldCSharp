// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System.Diagnostics;

namespace WestWorld.FSM
{
    using Messaging;

    /// <summary>
    /// State machine class. 
    /// </summary>
    /// <typeparam name="T">Type of context.</typeparam>
    /// <remarks>
    /// Inherit from this class and create some states to give your agents FSM functionality.
    /// </remarks>
    public class StateMachine<T>
    {
        /// <summary>
        /// The agent that owns this instance.
        /// </summary>
        private T Owner { get; set; }

        /// <summary>
        /// TODO
        /// </summary>
        public IState<T> CurrentState { get; set; }

        /// <summary>
        /// A record of the last state the agent was in.
        /// </summary>
        public IState<T> PreviousState { get; set; }

        /// <summary>
        /// This is called every time the FSM is updated.
        /// </summary>
        public IState<T> GlobalState { get; set; }

        /// <summary>
        /// Create an instance of class StateMachine.
        /// </summary>
        /// <param name="owner">The agent that owns this instance.</param>
        public StateMachine(T owner)
        {
            Debug.Assert(owner != null);

            Owner = owner;
        }

        /// <summary>
        /// Call this to update the FSM.
        /// </summary>
        public void Update()
        {
            Debug.Assert(Owner != null);

            // If a global state exists, call its execute method, else do nothing.
            if(GlobalState != null)
            {
                GlobalState.Execute(Owner);
            }

            // Same for the current state.
            if(CurrentState != null)
            {
                CurrentState.Execute(Owner);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool HandleMessage(Telegram message)
        {
            // First see if the current state is valid and that it can handle
            // the message.
            if(CurrentState != null && CurrentState.OnMessage(Owner, message))
            {
                return true;
            }

            // If not, and if a global state has been implemented, send 
            // the message to the global state
            if(GlobalState != null && GlobalState.OnMessage(Owner, message))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Change to a new state.
        /// </summary>
        /// <param name="state">New state.</param>
        public void ChangeState(IState<T> state)
        {
            Debug.Assert(state != null, "<StateMachine::ChangeState>: trying to change to NULL state");
            Debug.Assert(Owner != null);

            // Keep a record of the previous state.
            PreviousState = CurrentState;

            // Call the exit method of the existing state.
            CurrentState.Exit(Owner);

            // Change state to the new state.
            CurrentState = state;

            // Call the entry method of the new state.
            CurrentState.Enter(Owner);
        }

        /// <summary>
        /// Change state back to the previous state.
        /// </summary>
        public void RevertToPreviousState()
        {
            Debug.Assert(Owner != null);
            ChangeState(PreviousState);
        }

        /// <summary>
        /// Returns true if the current state's type is equal to the type of the
        /// class passed as a parameter. 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool IsInState(IState<T> state)
        {
            Debug.Assert(Owner != null);
            Debug.Assert(CurrentState != null);

            return CurrentState.GetType() == state.GetType();
        }
    }
}
