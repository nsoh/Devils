using System;
using System.Collections.Generic;

namespace Devils
{
    class TaskHandler<T>
    {
        Dictionary<string, T> m_Tasks;

        public TaskHandler()
        {
            m_Tasks = new Dictionary<string, T>();
        }

        public bool Add(string key, T task)
        {
            if(m_Tasks.ContainsKey(key))
            {
                return false;
            }

            m_Tasks.Add(key, task);
            return true;
        }

        public bool Remove(string key)
        {
            return m_Tasks.Remove(key);
        }

        public T Find(string key)
        {
            T task;
            if(!m_Tasks.TryGetValue(key, out task))
            {
                return default(T);
            }

            return task;
        }
    }
}