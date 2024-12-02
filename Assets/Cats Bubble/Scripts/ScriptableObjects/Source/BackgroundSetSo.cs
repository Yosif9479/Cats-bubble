using UnityEngine;

namespace Cats_Bubble.Scripts.ScriptableObjects.Source
{
    [CreateAssetMenu(fileName = "BackgroundSet", menuName = "ScriptableObjects/BackgroundSet")]
    public class BackgroundSetSo : ScriptableObject
    {
        public Sprite[] Sprites;
    }
}