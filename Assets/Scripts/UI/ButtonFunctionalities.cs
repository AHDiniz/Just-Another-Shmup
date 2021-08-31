using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JustAnotherShmup.UserInterface
{
    public class ButtonFunctionalities : MonoBehaviour
    {
        [SerializeField] private string gameSceneName;
        [SerializeField] private string mainMenuSceneName;
        [SerializeField] private bool canPause = false;
        [SerializeField] private GameObject pauseMenu;
        [SerializeField] private GameObject gameOverMenu;
        [SerializeField] private float timeToPlayGame = .5f;
        [SerializeField] private float timeToGameOver = .5f;
        [SerializeField] private float timeToQuitGame = 1f;

        private bool paused = false;

        private void Update()
        {
            if (canPause && Input.GetKeyDown(KeyCode.Escape)) PauseGame();
        }

        public void PlayGame()
        {
            StartCoroutine(PlayGameCoroutine());
        }

        private IEnumerator PlayGameCoroutine()
        {
            yield return new WaitForSeconds(timeToPlayGame);
            SceneManager.LoadScene(gameSceneName, LoadSceneMode.Single);
        }

        public void MainMenu()
        {
            if (paused) Time.timeScale = 1f;
            SceneManager.LoadScene(mainMenuSceneName, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            StartCoroutine(QuitGameCoroutine());
        }

        private IEnumerator QuitGameCoroutine()
        {
            yield return new WaitForSeconds(timeToQuitGame);
            Application.Quit();
        }

        public void PauseGame()
        {
            if (paused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
            paused = !paused;
        }

        public void GameOverMenu()
        {
            gameOverMenu.SetActive(true);
        }

        private IEnumerator GameOverCoroutine()
        {
            yield return new WaitForSeconds(timeToGameOver);
            gameOverMenu.SetActive(true);
        }
    }
}