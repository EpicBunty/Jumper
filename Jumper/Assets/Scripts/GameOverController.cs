using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverController : MonoBehaviour
{
    public Button restartButton;
    public Button mainMenuButton;

    private void Awake()
    {
        //restartButton.onClick.AddListener(LevelManager.Instance.ReloadLevel);
        //mainMenuButton.onClick.AddListener(LevelManager.Instance.LoadLobby);

        restartButton.onClick.AddListener(ReloadLevel);
        mainMenuButton.onClick.AddListener(MainMenu);

    }

    public void ReloadLevel()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}