
    
namespace SoundAndFX
{
    /// <summary>
    /// Интерфейс для остановки или воспроизведения звуков
    /// </summary>
    public interface ISoundSystem
    {
        /// <summary>
        /// Воспроизвести звук
        /// </summary>
        /// <param name="name">название звука</param>
        void PlaySound(string name);
        
        /// <summary>
        /// Остановить звук
        /// </summary>
        /// <param name="name">название звука</param>
        void StopSound(string name);
    }
}