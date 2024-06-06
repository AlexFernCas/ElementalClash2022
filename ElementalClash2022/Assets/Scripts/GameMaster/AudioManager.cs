using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public GameObject camara;
    public AudioClip unitDead;
    public AudioClip unitSpawn;
    public AudioClip unitDamage;
    public AudioClip bonusSpawn;
    public AudioClip playerScores;
    public AudioClip mlAgentScores;
    public AudioClip playerWins;
    public AudioClip mlAgentWins;
    private AudioSource audioSource;
    private AudioSource camaraAudioSource;
    
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;

        audioSource = GetComponent<AudioSource>();
        camaraAudioSource = camara.GetComponent<AudioSource>();
    }


    public void PlayUnitSpawnSound()
    {
        audioSource.PlayOneShot(unitSpawn);
    }
    public void PlayUnitDeadSound()
    {
        audioSource.PlayOneShot(unitDead);
    }


    public void PlayUnitDamageSound()
    {
        audioSource.PlayOneShot(unitDamage);
    }
 
    public void PlayBonusSpawnSound()
    {
        audioSource.PlayOneShot(bonusSpawn);
    }

    public void PlayPlayerScoresSound()
    {
        audioSource.PlayOneShot(playerScores);
    }

    public void PlayMLAgentScoresSound()
    {
        audioSource.PlayOneShot(mlAgentScores);
    }

    public void PlayPlayerWinsSound()
    {
        camaraAudioSource.volume = 0;
        audioSource.PlayOneShot(playerWins);
    }

    public void PlayMLAgentWins()
    {
        camaraAudioSource.volume = 0;
        audioSource.PlayOneShot(mlAgentWins);
    }

    public void Mute()
    {
        if (audioSource.volume != 0)
        {
            audioSource.volume = 0;
        } else
        {
            audioSource.volume = 0.2f;
        }
    }
}
