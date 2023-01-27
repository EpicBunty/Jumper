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
    [SerializeField] private GameObject LevelSelectionMenu;

    private void Awake()
    {

        Time.timeScale = 1;
        buttonPlay.onClick.AddListener(PlayGame);
        buttonBack.onClick.AddListener(GoBack);
        buttonQuit.onClick.AddListener(QuitGame);
        buttonContinue.onClick.AddListener(ContinueGame);

        //buttonQuit.onClick.AddListener(LevelManager.Instance.QuitGame);

        if (LevelManager.Instance.LastScene.buildIndex != 0)
        {
            buttonContinue.gameObject.SetActive(true);
        }
        else buttonContinue.gameObject.SetActive(false);

        //ButtonContinue.gameObject.SetActive(levelController.lastscene);
    }

    public void PlayGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelectionMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(LevelManager.Instance.LastSceneIndex);
    }

    void GoBack()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        LevelSelectionMenu.SetActive(false);
    }

    public void QuitGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonBack);
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}