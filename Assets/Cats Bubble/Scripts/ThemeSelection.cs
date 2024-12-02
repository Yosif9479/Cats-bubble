using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cats_Bubble.Scripts
{
    public class ThemeSelection : MonoBehaviour
    {
        [SerializeField] private Image _image;
        
        private int _index;
        
        public void Init(Sprite sprite, int index)
        {
            _image.sprite = sprite;
            _index = index;
        }

        public void OnSelected()
        {
            GlobalStorage.Theme = _index;
            SceneManager.LoadScene("Themes");
        }
    }
}