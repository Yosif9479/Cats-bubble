using System.Collections.Generic;
using UnityEngine;

namespace Cats_Bubble.Scripts
{
    public class ScreenEdgeGenerator : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            var screenEdges = new GameObject("Screen Edges");

            var edge = screenEdges.AddComponent<EdgeCollider2D>();

            edge.SetPoints(GeneratePoints());
        }

        private List<Vector2> GeneratePoints()
        {
            Vector2 leftDown = _camera.ScreenToWorldPoint(new Vector3(0, 0));
            Vector2 rightDown = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0));
            Vector2 leftTop = _camera.ScreenToWorldPoint(new Vector3(0, Screen.height));
            Vector2 rightTop = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

            return new List<Vector2>
            {
                leftDown, rightDown, rightTop, leftTop, leftDown
            };
        }
    }
}