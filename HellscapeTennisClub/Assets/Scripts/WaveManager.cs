using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    private int waveNumber = 3;
    private bool roundStarted = false;
    private Transform spawnPoint, spawnpoint1, spawnpoint2;
    private int aliveMonsters = 0;

    public GameObject monsterPrefab;
    private Transform target;

    public Sprite medMonsterSprite;
    public Sprite heavyMonsterSprite;


    // Start is called before the first frame update
    void Start()
    {
        spawnpoint1 = GameObject.Find("SpawnPoint1").transform;
        spawnpoint2 = GameObject.Find("SpawnPoint2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && roundStarted != true)
        {
            roundStarted = true;
            WaveInitiation();
        }

        target = GameObject.Find("Player").transform;

        aliveMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;
        Debug.Log(aliveMonsters);

        //ROUND END CONDITION AND EXECUTION
        if (aliveMonsters <= 0 && roundStarted == true)
        {
            waveNumber++;
            roundStarted = false;
        }
        
    }

    void WaveInitiation()
    {
        int numOfLight = 0;
        int numOfMed = 0;
        int numOfHeavy = 0;

        if (waveNumber == 1)
        {
            Debug.Log("Wave 1 Started");
            numOfLight = 8;
            numOfMed = 0;
            numOfHeavy = 0;
        }
        else if (waveNumber == 2)
        {
            Debug.Log("Wave 2 Started");
            numOfLight = 10;
            numOfMed = 5;
            numOfHeavy = 0;

        }
        else if (waveNumber == 3)
        {
            Debug.Log("Wave 3 Started");
            numOfLight = 10;
            numOfMed = 8;
            numOfHeavy = 2;

        }
        else if (waveNumber >= 4)
        {

        }
        else
        {
            Debug.Log("waveNumber Error");
        }

        StartCoroutine("LightSpawn", numOfLight);
        StartCoroutine("MedSpawn", numOfMed);
        StartCoroutine("HeavySpawn", numOfHeavy);
    }

    IEnumerator LightSpawn(int numOfLight)
    {
        while (numOfLight > 0)
        {
            ChooseSpawnPoint();
            GameObject monsterSpawn = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

            //Setting Monster target
            AIController aiScript = monsterSpawn.GetComponent<AIController>();
            aiScript.target = target;
            aiScript.speed = 750f;

            //Setting Monster Attack Damage
            MonsterDamage damageScript = monsterSpawn.GetComponent<MonsterDamage>();
            damageScript.damageAmount = 2;

            //Setting Monster Health and Resilience
            MonsterHealth healthScript = monsterSpawn.GetComponent<MonsterHealth>();
            healthScript.health = 75;
            healthScript.baseDamageTaken = 35;

            numOfLight--;
            yield return new WaitForSecondsRealtime(2);
        }
    }

    IEnumerator MedSpawn(int numOfMed)
    {
        while (numOfMed > 0)
        {
            ChooseSpawnPoint();
            GameObject monsterSpawn = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

            //Setting Monster target
            AIController aiScript = monsterSpawn.GetComponent<AIController>();
            aiScript.target = target;
            aiScript.speed = 650f;

            //Setting Monster Attack Damage
            MonsterDamage damageScript = monsterSpawn.GetComponent<MonsterDamage>();
            damageScript.damageAmount = 3;

            //Setting Monster Health and Resilience
            MonsterHealth healthScript = monsterSpawn.GetComponent<MonsterHealth>();
            healthScript.health = 125;
            healthScript.baseDamageTaken = 35;

            //Setting Monster Sprite
            SpriteRenderer spriteRenderer = monsterSpawn.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = medMonsterSprite;

            numOfMed--;
            yield return new WaitForSecondsRealtime(4);
        }
    }

    IEnumerator HeavySpawn(int numOfHeavy)
    {
        while (numOfHeavy > 0)
        {
            ChooseSpawnPoint();
            GameObject monsterSpawn = Instantiate(monsterPrefab, spawnPoint.position, Quaternion.identity);

            //Setting Monster target
            AIController aiScript = monsterSpawn.GetComponent<AIController>();
            aiScript.target = target;
            aiScript.speed = 550f;

            //Setting Monster Attack Damage
            MonsterDamage damageScript = monsterSpawn.GetComponent<MonsterDamage>();
            damageScript.damageAmount = 4;

            //Setting Monster Health and Resilience
            MonsterHealth healthScript = monsterSpawn.GetComponent<MonsterHealth>();
            healthScript.health = 160;
            healthScript.baseDamageTaken = 35;

            //Setting Monster Sprite
            SpriteRenderer spriteRenderer = monsterSpawn.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = heavyMonsterSprite;

            numOfHeavy--;
            yield return new WaitForSecondsRealtime(8);
        }
    }

    void ChooseSpawnPoint()
    {
        int spawnSelection = Random.Range(0,2);
            Debug.Log(spawnSelection);
            if (spawnSelection == 0)
            {
                spawnPoint = spawnpoint1;
            }
            else if (spawnSelection == 1)
            {
                spawnPoint = spawnpoint2;
            }
            else
            {
                spawnPoint = spawnpoint1;
            }
    }

}
