using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonQuit;
    [SerializeField] private GameObject levelselectionMenu;

    private void Awake()
    {

        Time.timeScale = 1;
        buttonPlay.onClick.AddListener(PlayGame);
        buttonBack.onClick.AddListener(GoBack);
        buttonQuit.onClick.AddListener(QuitGame);
        buttonContinue.onClick.AddListener(ContinueGame);
    }

    private void Start()
    {
        if (LevelManager.Instance.LastSceneIndex > 0)
            buttonContinue.gameObject.SetActive(true);
        else buttonContinue.gameObject.SetActive(false);
        //SoundManager.Instance.PlayBgMusic(Sounds.LobbyMusic);

    }
    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        levelselectionMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(LevelManager.Instance.LastSceneIndex);
    }

    void GoBack()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        levelselectionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}