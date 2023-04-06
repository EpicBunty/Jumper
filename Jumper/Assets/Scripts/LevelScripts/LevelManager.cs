using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    public int LastSceneIndex, CurrentSceneIndex, NextSceneIndex;

    public string[] Levels;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        Init();

    }

    private void Start()
    {
        if (GetLevelStatus(1) == LevelStatus.Locked)
        {
            SetLevelStatus(1, LevelStatus.Unlocked);
        }
    }
    public void Init()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NextSceneIndex = CurrentSceneIndex + 1;
        if (CurrentSceneIndex != 0)
        {
            LastSceneIndex = CurrentSceneIndex;
        }
    }

    public LevelStatus GetLevelStatus(int level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Levels[level], 0);
        return levelStatus;
    }

    public void SetLevelStatus(int level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(Levels[level], (int)levelStatus);
        Debug.Log("setting level " + level + " status to " + levelStatus);
    }

    public void LevelComplete()
    {
        Init();
        SetLevelStatus(CurrentSceneIndex, LevelStatus.Completed);
        if (NextSceneIndex < 3)

        {
            SetLevelStatus(NextSceneIndex, LevelStatus.Unlocked);
        }

    }


    public void LoadNextScene()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("level manager is loading next scene");// which is " + NextScene.name);
        SceneManager.LoadScene(NextSceneIndex);
        SoundManager.Instance.soundMusic.Stop();
        Init();
    }

}
