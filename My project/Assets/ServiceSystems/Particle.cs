using System;
using UnityEngine;

namespace SoundAndFX
{
    /// <summary>
    /// Класс партикла эффекта с именем
    /// </summary>
    [Serializable]
    public class Particle
    {
        public ParticleSystem Effect;
        public string Name;
    }
}