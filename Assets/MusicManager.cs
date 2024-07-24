using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource audioMusicSource;
    void Start()
    {
        audioMusicSource = GetComponent<AudioSource>();
    }
    public void SetVolume(float volume)
    {
        audioMusicSource.volume = volume;
    }
    public void PlayMusic(AudioClip audioClip)
    {
        audioMusicSource.clip = audioClip;
        audioMusicSource.Play();
    }
}
