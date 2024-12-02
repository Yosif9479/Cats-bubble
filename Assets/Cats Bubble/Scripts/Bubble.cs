using System;
using System.Linq;
using Cats_Bubble.Scripts.ScriptableObjects.Source;
using UnityEngine;
using UnityEngine.Events;

namespace Cats_Bubble.Scripts
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class Bubble : MonoBehaviour
    {
        public static event UnityAction Merged;

        [SerializeField] private BubbleSetSo _bubbleSet;
        [SerializeField] private float _flySpeed = 1f;
        [SerializeField] private float _strafeSpeed = 10;
        [SerializeField] private float _minOffsetFromBorders = 0.35f;

        public bool IsFlying { get; private set; }
        public bool AffectOnDeadzone { get; private set; }
        
        private Camera _camera;
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;

        public int Level { get; private set; }
        private float _maxPositionX;
        private float _minPositionX;

        private void Awake()
        {
            _camera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            InitMaxAndMinPosition();
        }

        public void Init(int level, bool startFlying = false)
        {
            Level = level;
            _spriteRenderer.sprite = _bubbleSet.Sprites.Length > level ? _bubbleSet.Sprites[level] : _bubbleSet.Sprites.Last();

            if (startFlying)
            {
                Fly();
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Bubble")) AffectOnDeadzone = true;

            if (IsFlying is false) return;
            
            var bubble = other.gameObject.GetComponent<Bubble>();
            
            if (bubble is null) return;
            
            if (bubble.Level != Level) return;
            
            bubble.IsFlying = false;
            
            Destroy(other.gameObject);
            
            Merge(other.transform.position);
        }

        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0) && !IsFlying) MoveToMouse();
        }

        private void Merge(Vector3 otherPosition)
        {
            Vector3 spawnPoint = Vector3.Lerp(transform.position, otherPosition, 0.5f);

            Bubble bubble = Instantiate(this);

            bubble.transform.position = spawnPoint;
            
            bubble.Init(Level += 1, true);
            
            Destroy(gameObject);
            
            Merged?.Invoke();
        }

        private void MoveToMouse()
        {
            Vector2 targetPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

            targetPoint.y = transform.position.y;

            targetPoint.x = Math.Clamp(targetPoint.x, _minPositionX, _maxPositionX);

            _rigidbody.position = Vector2.Lerp(_rigidbody.position, targetPoint, _strafeSpeed * Time.fixedDeltaTime);
        }

        private void InitMaxAndMinPosition()
        {
            Vector2 leftDown = _camera.ScreenToWorldPoint(new Vector3(0, 0));
            
            _minPositionX = leftDown.x + _minOffsetFromBorders;
            _maxPositionX = Math.Abs(leftDown.x) - _minOffsetFromBorders;
        }

        public void Fly()
        {
            IsFlying = true;
            _rigidbody.gravityScale = -_flySpeed;
        }
    }
}