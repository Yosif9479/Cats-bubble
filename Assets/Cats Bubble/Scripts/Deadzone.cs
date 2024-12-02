using UnityEngine;
using UnityEngine.Events;

namespace Cats_Bubble.Scripts
{
    public class Deadzone : MonoBehaviour
    {
        public static event UnityAction GameOver;
        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Bubble") is false) return;

            var bubble = other.GetComponent<Bubble>();
            
            if (bubble is null) return;

            if (bubble.AffectOnDeadzone)
            {
                GameOver?.Invoke();
            }
        }
    }
}