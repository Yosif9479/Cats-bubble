using UnityEngine;
using UnityEngine.Events;

namespace Cats_Bubble.Scripts
{
    public class PlayerInput : MonoBehaviour
    {
        public event UnityAction Shoot;

        private void Update()
        {
            if (Input.GetMouseButtonUp(0)) Shoot?.Invoke();
        }
    }
}