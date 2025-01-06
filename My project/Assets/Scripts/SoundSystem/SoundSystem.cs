using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace SoundAndFX
{
    /// <summary>
    /// Система звуков
    /// </summary>
    public class SoundSystem : MonoBehaviour, ISoundSystem
    {
        [SerializeField] private Sound[] _sounds;
        [SerializeField] private Sound[] _musics;

        public bool _isPlaying = true;

        private bool _isMusicOn;
        private bool _isSoundOn;

        private const string MUSIC_KEY = "isMusicOn";
        private const string SOUND_KEY = "isSoundOn";

        /// <summary>
        /// Инициализация настроек при старте
        /// </summary>
        private void Awake()
        {
            InitSetting();
        }

        /// <summary>
        /// Загружает значения включен ли звук или нет
        /// </summary>
        public void InitSetting()
        {
            _isMusicOn = PlayerPrefs.GetInt(MUSIC_KEY, 1) == 1;
            _isSoundOn = PlayerPrefs.GetInt(SOUND_KEY, 1) == 1;

            InitSounds();
            InitMusics();
            InitLevelMusic();
        }

        /// <summary>
        /// Воспроизвести звук
        /// </summary>
        /// <param name="name">название звука</param>
        public void PlaySound(string name)
        {
            if (_isSoundOn)
            {
                Sound playSound = GetSoundByName(name);
                // якщо не знайде за назвою трек
                if (playSound == null){
                    Debug.LogError("sound null - " + name);
                    string list = "[";
                    foreach(Sound s in _sounds){
                        list += s.Name;
                        list += " , ";
                    }
                    list += "]";
                    Debug.Log(list);
                }
                playSound?.Source.Play();
            }
        }

        /// <summary>
        /// Остановить звук
        /// </summary>
        /// <param name="name">название звука</param>
        public void StopSound(string name)
        {
            if (_isSoundOn)
            {
                Sound playSound = GetSoundByName(name);
                playSound?.Source.Stop();
            }
        }

        /// <summary>
        /// Остановка музыки в игре
        /// </summary>
        /// <param name="fadeDuration">длительность затухания</param>
        public void StopLevelMusic(float fadeDuration)
        {
            StartCoroutine(FadeMusic(false, fadeDuration));
        }

        /// <summary>
        /// Воспроизвести музыку в игре
        /// </summary>
        public void InitLevelMusic()
        {
            if (_isMusicOn)
            {
                foreach (var music in _musics)
                {
                    if (music.Source != null)
                    {
                        if (!music.Source.isPlaying)
                        {
                            music.Source.Play();
                        }

                        if(!music.isPlaying)
                        {
                            music.Source.Stop();
                        }
                    }
                    else
                    {
                        music.Source = gameObject.AddComponent<AudioSource>();
                        music.Source.clip = music.AudioClip;
                        music.Source.volume = music.Volume;
                        music.Source.loop = true;
                        music.Source.Play();
                    }
                }
            }
            else
            {
                foreach (var music in _musics)
                {
                    if (music.Source != null)
                        music.Source.Stop();
                }
            }
        }

        /// <summary>
        /// Подпрограмма затухания звука
        /// </summary>
        /// <param name="fadeIn">значение для проверки на значение затухания звука</param>
        /// <param name="fadeTime">время затухания</param>
        /// <returns></returns>
        private IEnumerator FadeMusic(bool fadeIn, float fadeTime)
        {
            float startVolume = _musics[0].Source.volume; 
            float endVolume = fadeIn ? _musics[0].Volume : 0f; 
            float t = 0f;

            while (t < fadeTime)
            {
                t += Time.deltaTime;
                foreach (var music in _musics)
                {
                    music.Source.volume = Mathf.Lerp(startVolume, endVolume, t / fadeTime);
                }
                yield return null;
            }

            if (!fadeIn && _musics[0].Source.isPlaying)
            {
                foreach (var music in _musics)
                {
                    music.Source.Stop();
                }
            }
        }

        /// <summary>
        /// Инициализирует звуки в игре
        /// </summary>
        private void InitSounds()
        {
            if (_isSoundOn)
            {
                foreach (var sound in _sounds)
                {
                    if (sound.Source != null)
                        return;

                    sound.Source = gameObject.AddComponent<AudioSource>();
                    sound.Source.clip = sound.AudioClip;
                    sound.Source.volume = sound.Volume;
                    sound.Source.loop = sound.Loop;
                    sound.Source.pitch = sound.Pitch;
                }
            }
            else
            {
                foreach (var sound in _sounds)
                {
                    if (sound.Source != null)
                        sound?.Source.Stop();
                }
            }
        }

        private void InitMusics()
        {
            if (_isMusicOn)
            {
                foreach (var music in _musics)
                {
                    if (music.Source != null)
                    {
                        if (!music.Source.isPlaying)
                        {
                            music.Source.Play();
                        }
                        return;
                    }

                    music.Source = gameObject.AddComponent<AudioSource>();
                    music.Source.clip = music.AudioClip;
                    music.Source.volume = music.Volume;
                    music.Source.loop = true;
                    music.Source.Play();
                }
            }
            else
            {
                foreach (var music in _musics)
                {
                    if (music.Source != null)
                        music?.Source.Stop();
                }
            }
        }

        // set pause for all sounds and musics
        public void PauseAllSoundsAndMusic(float delay)
        {
            _isPlaying = false;
            DOVirtual.DelayedCall(delay, () =>
            {
                foreach (var sound in _sounds)
                {
                    if (sound.Source != null && sound.Source.isPlaying)
                    {
                        sound.Source.Pause();
                    }
                }

                foreach (var music in _musics)
                {
                    if (music.Source != null && music.Source.isPlaying)
                    {
                        music.Source.Pause();
                    }
                }
            });
        }

        // resume all sounds and musics
        public void ResumeAllSoundsAndMusic()
        {
            _isPlaying = true;
            foreach (var sound in _sounds)
            {
                if (sound.Source != null && !sound.Source.isPlaying)
                {
                    sound.Source.UnPause();
                }
            }

            foreach (var music in _musics)
            {
                if (music.Source != null && !music.Source.isPlaying)
                {
                    music.Source.UnPause();
                }
            }
        }

        /// <summary>
        /// Получает звук от названия звука
        /// </summary>
        /// <param name="name">требуемое название для поиска</param>
        /// <returns></returns>

        private Sound GetSoundByName(string name)
            => Array.Find(_sounds, sound => sound.Name == name);

        /// <summary>
        /// Fades out a music track with the given name over a specified duration.
        /// </summary>
        /// <param name="musicName">The name of the music track to fade out.</param>
        /// <param name="fadeDuration">The duration of the fade-out effect.</param>

        public void FadeOutMusic(string musicName, float fadeDuration)
        {
            // Find the music track with the given name
            Sound music = GetMusicByName(musicName);
            if (music != null)
            {
                // Start fading out the music track
                StartCoroutine(FadeMusic(music, true, fadeDuration));
            }
            else
            {
                Debug.LogWarning("Music track with name '" + musicName + "' not found.");
            }
        }

        /// <summary>
        /// Coroutine for fading music tracks in or out over time.
        /// </summary>
        /// <param name="music">The music track to fade.</param>
        /// <param name="fadeIn">True to fade in, false to fade out.</param>
        /// <param name="fadeTime">The duration of the fade effect.</param>

        private IEnumerator FadeMusic(Sound music, bool fadeIn, float fadeTime)
        {
            if (fadeIn)
            {
                music.Source.Play();
            }

            float startVolume = music.Volume;
            float endVolume = fadeIn ? music.Volume : 0f;
            float elapsedTime = 0f;

            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / fadeTime);
                music.Source.volume = Mathf.Lerp(startVolume, endVolume, t);
                yield return null;
            }

            if (!fadeIn)
            {
                music.Source.Stop();
            }
        }

        /// <summary>
        /// Retrieves a music track by its name.
        /// </summary>
        /// <param name="name">The name of the music track.</param>
        /// <returns>The music track with the specified name, or null if not found.</returns>
        private Sound GetMusicByName(string name)
        {
            foreach (Sound music in _musics)
            {
                if (music.Name == name)
                {
                    return music;
                }
            }
            return null;
        }

        /// <summary>
        /// Fades in a music track with the given name over a specified duration.
        /// </summary>
        /// <param name="musicName">The name of the music track to fade in.</param>
        /// <param name="fadeDuration">The duration of the fade-in effect.</param>

        public void FadeInMusic(string musicName, float fadeDuration)
        {
            // Find the music track with the given name
            Sound music = GetMusicByName(musicName);
            if (music != null)
            {
                // Start fading in the music track
                StartCoroutine(FadeMusic(music, false, fadeDuration));
            }
            else
            {
                Debug.LogWarning("Music track with name '" + musicName + "' not found.");
            }
        }
    }
}