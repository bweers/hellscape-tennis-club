using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    private float timeDelay = 1f, maxTimeAlive = 5f;
    private int timeAlive = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LifeTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LifeTimer() {
         while (true) {
             timeAlive++;
             if (timeAlive >= maxTimeAlive)
             {
                 Destroy(gameObject);
             }
             yield return new WaitForSeconds(timeDelay);
         }
     }
}
