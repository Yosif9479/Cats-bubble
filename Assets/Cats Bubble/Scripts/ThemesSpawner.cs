using Cats_Bubble.Scripts.ScriptableObjects.Source;
using UnityEngine;

namespace Cats_Bubble.Scripts
{
    public class ThemesSpawner : MonoBehaviour
    {
        [SerializeField] private BackgroundSetSo _backgroundSet;
        [SerializeField] private ThemeSelection _themePrefab;
        [SerializeField] private Transform _scrollViewContent;

        private void Start()
        {
            for (int i = 0; i < _backgroundSet.Sprites.Length; i++)
            {
                Instantiate(_themePrefab, _scrollViewContent).Init(_backgroundSet.Sprites[i], i);
            }
        }
    }
}