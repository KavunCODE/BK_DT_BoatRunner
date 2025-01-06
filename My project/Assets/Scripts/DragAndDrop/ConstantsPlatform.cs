namespace AwesomeTools.DefinesConstant
{
    /// <summary>
    /// Класс, что проверяет платформу
    /// </summary>
    public class ConstantsPlatform
    {
        public static bool UNITY_EDITOR
        {
            get
            {
#if UNITY_EDITOR
                return true;
#endif
                return false;
            }
        }

        public static bool ANDROID
        {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                return true;
#endif
                return false;
            }
        }

        public static bool IOS
        {
            get
            {
#if UNITY_IOS && !UNITY_EDITOR
                return true;
#endif
                return false;
            }
        }

        public static bool WINDOWS
        {
            get
            {
#if !UNITY_ANDROID && !UNITY_IOS && !UNITY_EDITOR
                return true;
#endif
                return false;
            }
        }

    }
}