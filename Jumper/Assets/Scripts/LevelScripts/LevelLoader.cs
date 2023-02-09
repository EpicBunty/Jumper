using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    //public string LevelName;
    public int LevelIndex;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelIndex);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Locked");
                SoundManager.Instance.Play(Sounds.ButtonLocked);
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelIndex);
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelIndex);
                break;
        }
        //LevelManager.Instance.Init();


    }

}

