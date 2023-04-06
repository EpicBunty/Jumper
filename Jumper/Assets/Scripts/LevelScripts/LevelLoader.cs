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
                LevelManager.Instance.Init();
                SoundManager.Instance.soundMusic.Stop();
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(LevelIndex);
                SoundManager.Instance.soundMusic.Stop();
                LevelManager.Instance.Init();
                break;
        }


    }

}

