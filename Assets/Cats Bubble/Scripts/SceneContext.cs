using Cats_Bubble.Scripts.ScriptableObjects.Source;
using UnityEngine;
using UnityEngine.UI;

namespace Cats_Bubble.Scripts
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private Image _background;

        [SerializeField] private BackgroundSetSo _backgrounds;

        private void Start()
        {
            Application.targetFrameRate = 120;
            QualitySettings.vSyncCount = 0;
            if (_background != null) _background.sprite = _backgrounds.Sprites[GlobalStorage.Theme];
        }
    }
}