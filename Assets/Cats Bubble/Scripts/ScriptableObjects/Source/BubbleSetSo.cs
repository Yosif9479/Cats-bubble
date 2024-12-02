using UnityEngine;

namespace Cats_Bubble.Scripts.ScriptableObjects.Source
{
    [CreateAssetMenu(fileName = "BubbleSet", menuName = "ScriptableObjects/BubbleSet")]
    public class BubbleSetSo : ScriptableObject
    {
        public Sprite[] Sprites;
    }
}