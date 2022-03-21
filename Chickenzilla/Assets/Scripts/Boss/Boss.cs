using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject endingScreen;
    public float bossLife ;
    public float timeToVictory;                                //Délai entre la mort du sboss et l'apparition de l'écran
    private bool bossIsDead, victory;
    
    public AudioSource audioSource;
    public AudioClip sound;
    public AudioSource musicAudioSource;
    public AudioClip music;

    void Start()
    {
        endingScreen.SetActive(false);
    }

    void Update()
    {
        if (bossLife <= 0 && !bossIsDead)                       //Si la vache est morte le délai commence
        {
            audioSource.PlayOneShot(sound);
            ScoreManager.instance.score += 1000;
            victory = true;
            bossIsDead = true;
        }

        if (victory)
        {
            timeToVictory -= Time.deltaTime;
        }
        
        if (timeToVictory <= 0)                                 //L'écran de fin apparait
        {
            endingScreen.SetActive(true);
        }

        if (endingScreen.activeSelf)
        { 
            musicAudioSource.PlayOneShot(music);      
           //AudioManager.instance.BossTheme();
        }
        
    }
}