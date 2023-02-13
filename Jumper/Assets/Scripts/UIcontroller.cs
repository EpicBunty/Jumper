using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BronzeCoinsUI;
    [SerializeField] private TextMeshProUGUI FinalScore;
    [SerializeField] private TextMeshProUGUI levelindicatorUI;
    [SerializeField] private Button ContinueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private int BronzeCoins; 
    private int level;

    void Start()
    {
        restartButton.onClick.AddListener(ReloadLevel);
        mainMenuButton.onClick.AddListener(MainMenu);
        ContinueButton.onClick.AddListener(ContinueGame);
        BronzeCoins = 0;
        RefreshScore();
        RefreshLevelIndicator();
    }

    private void ContinueGame()
    {
        if (LevelManager.Instance.CurrentSceneIndex >= 2)
        {
            SceneManager.LoadScene(0);
        }
        else
        LevelManager.Instance.LoadNextScene();
    }
    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void MainMenu()
    {
       SceneManager.LoadScene(0);
    }

    public void BronzeCoinIncrement(int increment)
    {
        BronzeCoins += increment;
        RefreshScore();
    }

    private void RefreshScore()
    {
        BronzeCoinsUI.text = "- " + BronzeCoins;
        FinalScore.text = "S c o r e  =  " + BronzeCoins;
    }

    private void RefreshLevelIndicator()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        levelindicatorUI.text = "Level - " + level;
    }
}