using Enums;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuUI : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(StartGame);
            _quitButton.onClick.AddListener(Quit);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveListener(StartGame);
            _quitButton.onClick.RemoveListener(Quit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(SceneType.Gameplay.ToString());
        }

        private void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}