namespace Engine
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System;

    public class CommandDispatcher
    {

        private Dictionary<string, List<Delegate>> mEventListeners;

        #region 注册事件侦听器
        public void AddEventListener(string type, EventCallback listener)
        {
            RegisterEventListener(type, listener);
        }

        public void AddEventListener<T1>(string type, EventCallback<T1> listener)
        {
            RegisterEventListener(type, listener);
        }

        public void AddEventListener<T1, T2>(string type, EventCallback<T1, T2> listener)
        {
            RegisterEventListener(type, listener);
        }

        public void AddEventListener<T1, T2, T3>(string type, EventCallback<T1, T2, T3> listener)
        {
            RegisterEventListener(type, listener);
        }

        public void AddEventListener<T1, T2, T3, T4>(string type, EventCallback<T1, T2, T3, T4> listener)
        {
            RegisterEventListener(type, listener);
        }

        public void AddEventListener<T1, T2, T3, T4, T5>(string type, EventCallback<T1, T2, T3, T4, T5> listener)
        {
            RegisterEventListener(type, listener);
        }

        private void RegisterEventListener(string type, Delegate listener)
        {
            if (mEventListeners == null)
                mEventListeners = new Dictionary<string, List<Delegate>>();

            if (!mEventListeners.ContainsKey(type))
            {
                mEventListeners[type] = new List<Delegate>();
                mEventListeners[type].Add(listener);
            }
            else
            {
                List<Delegate> listeners = mEventListeners[type];
                if (listeners.Contains(listener) == false)
                    listeners.Add(listener);
            }
        }

        #endregion

        #region 删除事件侦听器
        public void RemoveEventListener(string type, EventCallback listener)
        {
            DeleteEventListener(type, listener);
        }

        public void RemoveEventListener<T1>(string type, EventCallback<T1> listener)
        {
            DeleteEventListener(type, listener);
        }

        public void RemoveEventListener<T1, T2>(string type, EventCallback<T1, T2> listener)
        {
            DeleteEventListener(type, listener);
        }

        public void RemoveEventListener<T1, T2, T3>(string type, EventCallback<T1, T2, T3> listener)
        {
            DeleteEventListener(type, listener);
        }

        public void RemoveEventListener<T1, T2, T3, T4>(string type, EventCallback<T1, T2, T3, T4> listener)
        {
            DeleteEventListener(type, listener);
        }

        public void RemoveEventListener<T1, T2, T3, T4, T5>(string type, EventCallback<T1, T2, T3, T4, T5> listener)
        {
            DeleteEventListener(type, listener);
        }

        private void DeleteEventListener(string type, Delegate listener)
        {
            if (mEventListeners != null)
            {

                if (mEventListeners.ContainsKey(type))
                {
                    List<Delegate> listeners = mEventListeners[type];
                    int numListeners = listeners.Count;
                    List<Delegate> remainingListeners = new List<Delegate>();

                    for (int i = 0; i < numListeners; ++i)
                        if (listeners[i] != listener) remainingListeners.Add(listeners[i]);

                    mEventListeners[type] = remainingListeners;
                }
            }
        }
        #endregion

        #region 删除指定类型的所有关联事件侦听，如果参数为null则删除当前注册器中所有的函数侦听
        public void RemoveEventListeners(string type = null)
        {
            if (type != null && mEventListeners != null)
                mEventListeners.Remove(type);
            else
                mEventListeners = null;
        }
        #endregion

        #region 派发事件
        public void Dispatch(string type)
        {
            if ((mEventListeners == null || !mEventListeners.ContainsKey(type)))
                return;
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            int numListeners = listeners == null ? 0 : listeners.Count;
            if (numListeners > 0)
            {
                for (int i = 0; i < numListeners; ++i)
                {
                    EventCallback listener = listeners[i] as EventCallback;
                    listener();
                }
            }
        }
        public void Dispatch<T1>(string type, T1 t1)
        {
            if ((mEventListeners == null || !mEventListeners.ContainsKey(type)))
                return;
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            int numListeners = listeners == null ? 0 : listeners.Count;
            if (numListeners > 0)
            {
                for (int i = 0; i < numListeners; ++i)
                {
                    EventCallback<T1> listener = listeners[i] as EventCallback<T1>;
                    if (listener != null)
                    {
                        listener(t1);
                    }
                }
            }
        }

        public void Dispatch<T1, T2>(string type, T1 t1, T2 t2)
        {
            if ((mEventListeners == null || !mEventListeners.ContainsKey(type)))
                return;
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            int numListeners = listeners == null ? 0 : listeners.Count;
            if (numListeners > 0)
            {
                for (int i = 0; i < numListeners; ++i)
                {
                    EventCallback<T1, T2> listener = listeners[i] as EventCallback<T1, T2>;
                    if (listener != null)
                    {
                        listener(t1, t2);
                    }
                }
            }
        }

        public void Dispatch<T1, T2, T3>(string type, T1 t1, T2 t2, T3 t3)
        {
            if ((mEventListeners == null || !mEventListeners.ContainsKey(type)))
                return;
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            int numListeners = listeners == null ? 0 : listeners.Count;
            if (numListeners > 0)
            {
                for (int i = 0; i < numListeners; ++i)
                {
                    EventCallback<T1, T2, T3> listener = listeners[i] as EventCallback<T1, T2, T3>;
                    if (listener != null)
                    {
                        listener(t1, t2, t3);
                    }
                }
            }
        }

        public void Dispatch<T1, T2, T3, T4>(string type, T1 t1, T2 t2, T3 t3, T4 t4)
        {
            if ((mEventListeners == null || !mEventListeners.ContainsKey(type)))
                return;
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            int numListeners = listeners == null ? 0 : listeners.Count;
            if (numListeners > 0)
            {
                for (int i = 0; i < numListeners; ++i)
                {
                    EventCallback<T1, T2, T3, T4> listener = listeners[i] as EventCallback<T1, T2, T3, T4>;
                    if (listener != null)
                    {
                        listener(t1, t2, t3, t4);
                    }
                }
            }
        }

        public void Dispatch<T1, T2, T3, T4, T5>(string type, T1 t1, T2 t2, T3 t3, T4 t4, T5 t5)
        {
            if ((mEventListeners == null || !mEventListeners.ContainsKey(type)))
                return;
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            int numListeners = listeners == null ? 0 : listeners.Count;
            if (numListeners > 0)
            {
                for (int i = 0; i < numListeners; ++i)
                {
                    EventCallback<T1, T2, T3, T4, T5> listener = listeners[i] as EventCallback<T1, T2, T3, T4, T5>;
                    if (listener != null)
                    {
                        listener(t1, t2, t3, t4, t5);
                    }
                }
            }
        }

        #endregion

        #region 是否已经添加该类型的侦听事件
        public bool HasEventListener(string type)
        {
            List<Delegate> listeners = mEventListeners != null ? mEventListeners[type] : null;
            return listeners != null ? listeners.Count != 0 : false;
        }
        #endregion
    }
    public delegate void EventCallback();
    public delegate void EventCallback<T>(T arg1);
    public delegate void EventCallback<T1, T2>(T1 arg1, T2 arg2);
    public delegate void EventCallback<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
    public delegate void EventCallback<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate void EventCallback<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
}