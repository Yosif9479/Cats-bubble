using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cats_Bubble.Scripts.SceneUiManagers
{
    public class MenuUiManager : MonoBehaviour
    {
        public void OnStartBtnClicked()
        {
            SceneManager.LoadScene("Game");
        }

        public void OnSettingsBtnClicked()
        {
            SceneManager.LoadScene("Themes");
        }
    }
}