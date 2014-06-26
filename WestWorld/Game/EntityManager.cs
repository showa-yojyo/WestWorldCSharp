// Original author:
//   Programming Game AI by Example, Mat Buckland, 2002.
//   (http://www.jblearning.com/catalog/9781556220784/)

using System.Collections.Generic;
using System.Diagnostics;

namespace WestWorld.Game
{
    public class EntityManager
    {
        /// <summary>
        /// To facilitate quick lookup the entities are stored in a Dictionary, in which
        /// pointers to entities are cross referenced by their identifying number
        /// </summary>
        private IDictionary<int, BaseGameEntity> EntityMap = new Dictionary<int, BaseGameEntity>();

        private static readonly EntityManager instance = new EntityManager();

        private EntityManager()
        {
        }

        /// <summary>
        /// Singleton interface.
        /// </summary>
        public static EntityManager Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Returns the entity with the ID given as a parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseGameEntity GetEntityFromID(int id)
        {
            BaseGameEntity entity = null;
            if(!EntityMap.TryGetValue(id, out entity))
            {
                Debug.Assert(entity != null, "<EntityManager::GetEntityFromID>: invalid ID");
            }

            return entity;
        }

        /// <summary>
        /// This method stores a pointer to the entity in the std::vector
        /// m_Entities at the index position indicated by the entity's ID
        /// (makes for faster access)
        /// </summary>
        /// <param name="entity"></param>
        public void RegisterEntity(BaseGameEntity entity)
        {
            EntityMap.Add(entity.ID, entity);
        }

        /// <summary>
        /// This method removes the entity from the list
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(BaseGameEntity entity)
        {
            EntityMap.Remove(entity.ID);
        }
    }
}
