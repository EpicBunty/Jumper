using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;

    private Scene CurrentScene;
    //private Scene NextScene;
    public Scene LastScene;

    public int LastSceneIndex;
    public int CurrentSceneIndex;
    public int NextSceneIndex;

    public string[] Levels;

    public static LevelManager Instance { get { return instance; } }

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

        //CurrentScene = SceneManager.GetActiveScene();
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        NextSceneIndex = CurrentSceneIndex + 1;
        //NextScene = SceneManager.GetSceneByBuildIndex(NextSceneIndex);
        if (CurrentSceneIndex != 0)
        {
            LastSceneIndex = CurrentSceneIndex;
        }

        Debug.Log("Current Scene is " + CurrentScene.name);
        //Debug.Log("Next Scene is " + NextScene.name);
        //Debug.Log("Next Scene is " + SceneManager.GetSceneByBuildIndex(NextSceneIndex).name;
    }

    public LevelStatus GetLevelStatus(int level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(Levels[level], 0);
        return levelStatus;
    }

    public void SetLevelStatus(int level, LevelStatus levelStatus)
    {
        //Init();
        PlayerPrefs.SetInt(Levels[level], (int)levelStatus);
        Debug.Log("setting level " + level + " status to " + levelStatus);
    }

    public void MarkCurrentLevelComplete()
    {
        SetLevelStatus(CurrentSceneIndex, LevelStatus.Completed);
    }

    public void MarkNextLevelUnlocked()
    {
        SetLevelStatus(NextSceneIndex, LevelStatus.Unlocked);
    }

    public void LoadNextScene()
    {
        //Init();
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("level manager is loading next scene");// which is " + NextScene.name);
        if (CurrentSceneIndex > 4)
        {
            SceneManager.LoadScene(0);
        }
        else
            SceneManager.LoadScene(NextSceneIndex);
    }

}
