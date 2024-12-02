using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cats_Bubble.Scripts.SceneUiManagers
{
    public class ThemesUiManager : MonoBehaviour
    {
        public void OnBackBtnClicked()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}