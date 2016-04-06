namespace Engine
{
    using UnityEngine;
    using System.Collections;

    //负责游戏全局事件通信
    public class GameDispatcher : EventDispatcher
    {
        private static GameDispatcher m_Instance;
        private GameDispatcher() 
        { 
            
        }

        public static GameDispatcher Instance {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new GameDispatcher();
                }
                return m_Instance;
            }
        }
    }
}
