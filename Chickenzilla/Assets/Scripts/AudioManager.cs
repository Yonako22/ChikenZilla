using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public static AudioManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("PLus d'une instance de AudioManager dans la scene");
            return;
        }
      
        instance = this;
    }
    
    private void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    public void BossTheme()
    {
        audioSource.clip = playlist[1];
        audioSource.Play();
    }
    public void EndingScreenTheme()
    {
        audioSource.clip = playlist[2];
        audioSource.Play();
    }
}
