using UnityEngine;

namespace Cats_Bubble.Scripts
{
    public class GlobalStorage
    {
        public static int Theme
        {
            get => PlayerPrefs.HasKey("Theme") is false ? 0 : PlayerPrefs.GetInt("Theme");

            set => PlayerPrefs.SetInt("Theme", value);
        }
    }
}
