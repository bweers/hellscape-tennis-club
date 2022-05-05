using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSound : MonoBehaviour
{

    public AudioSource monsterSound;

    public AudioClip[] audioClipArray;

    void Awake(){
        monsterSound = GetComponent<AudioSource> ();
    }

    public void HitSound()
    {
        monsterSound.clip=audioClipArray[Random.Range(0,audioClipArray.Length)];
        monsterSound.PlayOneShot(monsterSound.clip);
    }
}
