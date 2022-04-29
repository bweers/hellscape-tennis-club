using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int health;
    public int baseDamageTaken;
    public float speedDamageModifier;
    public GameObject bloodParticleSys;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision");
        if (col.gameObject.tag == "Ball")
        {
            int ballSpeed = (int)col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;

            health -= baseDamageTaken * (int)(ballSpeed * speedDamageModifier) / 20; // 20 is a random number that just sort of feels right

            Debug.Log(ballSpeed);
            Debug.Log(health);

            if (health <= 0)
            {
                Death();
            }
        }
    }

    void Death()
    {
        //Insert VFX or other stuff here
        GameObject particles = Instantiate(bloodParticleSys, gameObject.transform.position, Quaternion.identity);
        particles.SetActive(true);

        // ParticleSystem particles = gameObject.GetComponent<ParticleSystem>();
        // particles.emission.enabled = true;


        Destroy(gameObject);
    }
}
