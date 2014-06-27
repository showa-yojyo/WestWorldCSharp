// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System;
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
            Miner Bob = new Miner(EntityType.Bob);
            
            // Create his wife.
            MinersWife Elsa = new MinersWife(EntityType.Elsa);

            //register them with the entity manager
            var mgr = EntityManager.Instance;
            mgr.RegisterEntity(Bob);
            mgr.RegisterEntity(Elsa);

            var dispatcher = MessageDispatcher.Instance;

            // Simply run Bob and Elsa through a few Update calls.
            for(int i = 0; i < 20; ++i)
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
