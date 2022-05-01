using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    public AudioClip racketHit1, racketHit2, racketHit3;
    public AudioClip racketsweetener1, racketsweetener2, racketsweetener3;
    private AudioClip racketHitSound, racketSweetenerSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioRacketHit(int power)
    {
        int randomInt = Random.Range(1,4);
        switch (randomInt)
        {
        case 1:
            racketHitSound = racketHit1;
            break;
        case 2:
            racketHitSound = racketHit2;
            break;
        case 3:
            racketHitSound = racketHit3;
            break;
        default:
            racketHitSound = racketHit1;
            Debug.Log("Audio Switch Default");
            break;
        }

        randomInt = Random.Range(1,4);
        switch (randomInt)
        {
        case 1:
            racketSweetenerSound = racketsweetener1;
            break;
        case 2:
            racketSweetenerSound = racketsweetener2;
            break;
        case 3:
            racketSweetenerSound = racketsweetener3;
            break;
        default:
            racketSweetenerSound = racketsweetener1;
            Debug.Log("Audio Switch Default");
            break;
        }

        float volume = Mathf.Clamp(power/30f, 0f, 0.5f);
        Debug.Log(volume);

        audioSource.PlayOneShot(racketHitSound, volume);
        audioSource.PlayOneShot(racketSweetenerSound, volume/2);

    }
}
