using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Player") {
            GameObject Player = GameObject.Find("Player");
            PlayerHealth PlayerHealth = Player.GetComponent<PlayerHealth>();
            PlayerHealth.TakeDamage(2);
            Debug.Log("Player Damaged");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
