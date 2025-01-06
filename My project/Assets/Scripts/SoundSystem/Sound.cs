using System;
using UnityEngine;

namespace SoundAndFX
{
    /// <summary>
    /// Класс, что отвечает за свойства и настройку звука
    /// </summary>
    [Serializable]
    public class Sound
    {
        [SerializeField] public AudioClip _audioClip;
        [SerializeField] private string _name;

        [Range(0f, 1f)]
        [SerializeField] private float _volume;
        [Range(0f, 3f)]
        [SerializeField] private float _pitch;

        [SerializeField] private bool _loop;

        [SerializeField] public bool isPlaying = true;

        public float Volume => _volume;
        public float Pitch => _pitch;
        public string Name => _name;
        public bool Loop => _loop;

        public AudioClip AudioClip => _audioClip;

        [HideInInspector]
        public AudioSource Source;
    }
}