using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Cats_Bubble.Scripts.SceneUiManagers
{
    public class GameUiManager : MonoBehaviour
    {
        [SerializeField] private GameObject _endMenu;
        [SerializeField] private Text _scoreText;
        private int _score;

        private void OnEnable()
        {
            Bubble.Merged += OnBubbleMerged;
            Deadzone.GameOver += OnGameOver;
        }

        private void OnBubbleMerged()
        {
            _score++;
        }

        private void OnGameOver()
        {
            Time.timeScale = 0;

            if (_endMenu != null)
            {
                _endMenu.SetActive(true);
            }
            
            if (_scoreText != null)
            {
                _scoreText.text = _score.ToString();
            }
        }

        public void OnHomeBtnClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Menu");
        }

        public void OnRestartBtnClicked()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Game");
        }
        
        public void OnPauseBtnClicked()
        {
            OnHomeBtnClicked();
        }

        public void OnResumeBtnClicked()
        {
            Time.timeScale = 1;
            _endMenu.SetActive(false);
        }
    }
}