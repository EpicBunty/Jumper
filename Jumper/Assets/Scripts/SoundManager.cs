using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    [SerializeField] private AudioSource soundMusic;
    [SerializeField] public AudioSource soundEffect;
    [SerializeField] private SoundType[] sounds;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        if (LevelManager.Instance.CurrentSceneIndex == 0)
        {
            PlayBgMusic(Sounds.LobbyMusic);
        }
        else
        {
            PlayBgMusic(Sounds.LevelMusic);
        }
    }
    public void PlayBgMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Clip not found for soundtype: " + sound);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.clip = clip;
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Clip not found for soundtype: " + sound);
        }
    }

    public void Play(Sounds sound, float volume)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.clip = clip;
            soundEffect.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogError("Clip not found for soundtype: " + sound);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType sounditem = Array.Find(sounds, item => item.soundType == sound);
        if (sounditem != null) return sounditem.soundClip;
        return null;
    }
}



[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    ButtonLocked,
    ButtonBack,
    LobbyMusic,
    LevelMusic,
    PlayerMove,
    Collectible,
    /*PlayerDeath,
    PlayerTakeDamage,
    Teleporter,
    JumpUp,
    JumpLand,*/


}
