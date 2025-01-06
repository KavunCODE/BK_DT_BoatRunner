using System.Collections.Generic;
using SoundAndFX;
using UnityEngine;
using System;

    /// <summary>
    /// Локатор сервісів, який виконує функції
    /// зберіання об'єктів, які мають властивості
    /// сінглтону, але не є такими.
    /// </summary>
    public class ServiceLocator
    {
        private readonly Dictionary<string, object> _services = new Dictionary<string, object>();
        public static ServiceLocator Current { get; private set; }

        /// <summary>
        /// Ініціалізація
        /// </summary>
        public static void Initialize()
        {
            Current = new ServiceLocator();
        }

        /// <summary>
        /// Реєструємо клас, який виконує функцію сінглтона, 
        /// тим саме зменшуємо явне прокидування залежностей.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service"></param>
        public void Register<T>(T service)
        {
            string key = typeof(T).Name;
            if(_services.ContainsKey(key))
            {
                Debug.LogError("Attempted to register service falied. He already is");
                return;
            }
            _services.Add(key, service);
        }

        /// <summary>
        /// Якщо сервіс не потрібен, то є можливість його 
        /// видалити
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void Unregister<T>()
        {
            string key = typeof(T).Name;
            if(!_services.ContainsKey(key))
            {
                Debug.LogError("An attempt to unregister a service failed. Not have registered service");
                return;
            }
            _services.Remove(key);
        }

        /// <summary>
        /// Отримання конкретного сервісу
        /// для використання
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Get<T>()
        {
            string key = typeof(T).Name;
            if(!_services.ContainsKey(key))
            {
                Debug.LogError($"Not have registered service: {key}");
                throw new InvalidOperationException();
            }

            return (T)_services[key];
        }
    }