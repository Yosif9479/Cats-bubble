using UnityEngine;
using Random = UnityEngine.Random;

namespace Cats_Bubble.Scripts
{
    public class BubbleSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerInput _input;
        [SerializeField] private Bubble _bubblePrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _cooldown;
        [SerializeField] private int _maxSpawnLevel;

        private float _currentCooldown;
        private Bubble _currentBubble;

        private void Start()
        {
            _currentCooldown = _cooldown;
            Spawn();
        }

        private void Update()
        {
            _currentCooldown -= Time.deltaTime;
            
            if (_currentCooldown <= 0 && _currentBubble is null) Spawn();
        }

        private void OnEnable()
        {
            _input.Shoot += TryShoot;
        }

        private void OnDisable()
        {
            _input.Shoot -= TryShoot;
        }

        private void TryShoot()
        {
            if (_currentBubble is null) return;
            
            _currentBubble.Fly();

            _currentBubble = null;

            _currentCooldown = _cooldown;
        }

        private void Spawn()
        {
            _currentBubble = Instantiate(_bubblePrefab);
            _currentBubble.transform.position = _spawnPoint.position;
            _currentBubble.Init(Random.Range(0, _maxSpawnLevel));
        }
    }
}