// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

namespace WestWorld
{
    /// <summary>
    /// Interface to define an interface for a state.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// This will execute when the state is entered.
        /// </summary>
        /// <param name="miner"></param>
        void Enter(Miner miner);

        /// <summary>
        /// This is the state's normal update function.
        /// </summary>
        /// <param name="miner"></param>
        void Execute(Miner miner);

        /// <summary>
        /// This will execute when the state is exited.
        /// </summary>
        /// <param name="miner"></param>
        void Exit(Miner miner);
    }
}
