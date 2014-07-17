// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;
using System.Linq;
using System.Threading;

namespace WestWorld
{
    using Game;
    using Messaging;

    /// <summary>
    /// This class corresponds to main.cpp in the original C++ WestWorld project.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create a miner.
            var Bob = new Miner(EntityType.Bob);
            
            // Create his wife.
            var Elsa = new MinersWife(EntityType.Elsa);

            // Register them with the entity manager
            var mgr = EntityManager.Instance;
            mgr.RegisterEntity(Bob);
            mgr.RegisterEntity(Elsa);

            var dispatcher = MessageDispatcher.Instance;

            // Simply run Bob and Elsa through a few Update calls.
            foreach(var i in Enumerable.Range(0, 20))
            {
                Bob.Update();
                Elsa.Update();

                // Dispatch any delayed messages
                dispatcher.DispatchDelayedMessages();

                Thread.Sleep(800);
            }

            // Wait for a keypress before exiting.
            Console.ReadKey();
        }
    }
}
