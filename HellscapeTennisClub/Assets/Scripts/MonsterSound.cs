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

    // Start is called before the first frame update
    void Start()
    {
        monsterSound.clip=audioClipArray[Random.Range(0,audioClipArray.Length)];
        monsterSound.PlayOneShot(monsterSound.clip);
    }
}
