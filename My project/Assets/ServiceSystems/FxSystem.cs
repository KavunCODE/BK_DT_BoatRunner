using System;
using System.Collections.Generic;
using UnityEngine;

namespace SoundAndFX
{
    /// <summary>
    /// Класс контроля эффектов в игре
    /// </summary>
    public class FxSystem : MonoBehaviour
    {
        [SerializeField] private Particle[] _particles;
        private Dictionary<string, ParticleSystem> _particleSystems = new Dictionary<string, ParticleSystem>();

        #region Singleton

        public static FxSystem Instance { get; private set; }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        #endregion Singleton

        /// <summary>
        /// Воспроизведение эффекта частиц по имени в указанной позиции с необязательным родительским преобразованием
        /// </summary>
        /// <param name="name">название эффекта</param>
        /// <param name="position">позиция для эффекта</param>
        /// <param name="parent">родитель для эффекта</param>
        public void PlayEffect(string name, Vector3 position, Transform parent = null)
        {
            Particle currentParticle = GetParticleByName(name);
            ParticleSystem effectGO = Instantiate(currentParticle.Effect, position, Quaternion.identity);
            if (effectGO != null)
            {
                if (parent != null)
                {
                    SetParent(effectGO, parent);
                }
                _particleSystems[name] = effectGO;
            }
        }

        /// <summary>
        /// Останавливает эффект частиц по названию
        /// </summary>
        /// <param name="name">название эффекта</param>
        public void StopEffect(string name)
        {
            if (_particleSystems.ContainsKey(name))
            {
                ParticleSystem particleSystem = _particleSystems[name];
                particleSystem.Stop();
                _particleSystems.Remove(name);
            }
        }

        /// <summary>
        /// Воспроизведение эффекта частиц по индексу в указанной позиции с необязательным родительским преобразованием
        /// </summary>
        /// <param name="index">индекс для получение эффекта</param>
        /// <param name="position">позиция эффекта</param>
        /// <param name="parent">родитель для эффекта</param>
        public void PlayEffect(int index, Vector3 position, Transform parent = null)
        {
            Particle particleSystemEffect = GetParticleByIndex(index);
            ParticleSystem particleSystemGO = Instantiate(particleSystemEffect.Effect, position, Quaternion.identity);
            if (particleSystemGO != null)
            {
                if (parent != null)
                {
                    SetParent(particleSystemGO, parent);
                }
                _particleSystems[GetNameByIndex(index)] = particleSystemGO;
            }
        }

        /// <summary>
        /// Устанавливает родителя системы частиц в указанное преобразование
        /// </summary>
        /// <param name="child">эффект</param>
        /// <param name="parent">желаемый родитель эффекта</param>
        private void SetParent(ParticleSystem child, Transform parent)
        {
            child.gameObject.transform.parent = parent;
        }

        /// <summary>
        /// Получение количество систем частиц
        /// </summary>
        /// <returns>возвращает количество систем частиц</returns>
        public int GetCountParticles()
        {
            return _particleSystems.Count;
        }

        /// <summary>
        /// Получить эффект по его названию
        /// </summary>
        /// <param name="name">название эффекта</param>
        /// <returns>возвращат эффект</returns>
        private Particle GetParticleByName(string name)
        {
            Particle particle = Array.Find(_particles, p => p.Name == name);

            if (particle != null)
            {
                return particle;
            }
            else
            {
                Debug.LogError("Name of effect is not correct");
                return null;
            }
        }

        /// <summary>
        /// Получить эффект по его индексу
        /// </summary>
        /// <param name="index">индекс эффекта</param>
        /// <returns></returns>
        private Particle GetParticleByIndex(int index)
        {
            return _particles[index];
        }

        /// <summary>
        /// Получить название эффекта по его индексу
        /// </summary>
        /// <param name="index">индекс эффекта</param>
        /// <returns></returns>
        private string GetNameByIndex(int index)
        {
            return _particles[index].Name;
        }
    }
}