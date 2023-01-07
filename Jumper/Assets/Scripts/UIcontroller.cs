using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI BronzeCoinsUI;
    //[SerializeField] private TextMeshProUGUI levelindicatorUI;


    private int BronzeCoins = 0;
    private int level;

    void Start()
    {
        RefreshScore();
        //RefreshLevelIndicator();
    }

    public void BronzeCoinIncrement(int increment)
    {
        BronzeCoins += increment;
        RefreshScore();
    }

    private void RefreshScore()
    {
        BronzeCoinsUI.text = "- " + BronzeCoins;
    }

    /*private void RefreshLevelIndicator()
    {
        level = SceneManager.GetActiveScene().buildIndex;// +1;
        levelindicatorUI.text = "Level : " + level;
    }*/
}