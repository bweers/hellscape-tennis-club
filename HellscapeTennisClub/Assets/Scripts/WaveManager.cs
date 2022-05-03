using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private int waveNumber = 1;
    private bool roundStarted = false;
    private Transform spawnPoint, spawnpoint1, spawnpoint2;
    private int aliveMonsters = 0;

    public GameObject monsterPrefab;
    public GameObject bloodParticleSys;
    private Transform target;

    public Sprite medMonsterSprite;
    public Sprite heavyMonsterSprite;

    public GameObject wavePrompt;
    public PlayerController playerScript;
    public GameObject confettiParticleSys;


    // Start is called before the first frame update
    void Start()
    {
        spawnpoint1 = GameObject.Find("SpawnPoint1").transform;
        spawnpoint2 = GameObject.Find("SpawnPoint2").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && roundStarted != true && playerScript.movementAllowed)
        {
            wavePrompt.SetActive(false);
            WaveInitiation();
            Debug.Log(waveNumber);
        }

        target = GameObject.Find("Player").transform;

        aliveMonsters = GameObject.FindGameObjectsWithTag("Monster").Length;

        // ROUND END CONDITION AND EXECUTION
        if (aliveMonsters <= 0 && roundStarted == true && waveNumber < 4)
        {
            waveNumber++;
            wavePrompt.SetActive(true);
            Debug.Log("End of Wave");
            roundStarted = false;
        }
        
    }

    public void WaveInitiation()
    {
        roundStarted = true;
        
        int numOfLight = 0;
        int numOfMed = 0;
        int numOfHeavy = 0;

        if (waveNumber == 1)
        {
            Debug.Log("Wave 1 Started");
            // numOfLight = 12;
            // numOfMed = 1;
            // numOfHeavy = 0;
            numOfLight = 2;
            numOfMed = 0;
            numOfHeavy = 0;
        }
        else if (waveNumber == 2)
        {
            Debug.Log("Wave 2 Started");
            numOfLight = 20;
            numOfMed = 9;
            numOfHeavy = 1;

        }
        else if (waveNumber == 3)
        {
            Debug.Log("Wave 3 Started");
            numOfLight = 20;
            numOfMed = 15;
            numOfHeavy = 4;

        }
        else if (waveNumber == 4)
        {
            //ENTER WINNING FX OR OTHER SCRIPTS HERE
            GameObject confetti = Instantiate(confettiParticleSys, new Vector3(-0.8f, 17f, 0f), Quaternion.identity);
            wavePrompt.SetActive(false);
            waveNumber++;
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
            aiScript.speed = 620f;

            //Setting Monster Attack Damage
            MonsterDamage damageScript = monsterSpawn.GetComponent<MonsterDamage>();
            damageScript.damageAmount = 2;

            //Setting Monster Health and Resilience
            MonsterHealth healthScript = monsterSpawn.GetComponent<MonsterHealth>();
            healthScript.health = 50;
            healthScript.baseDamageTaken = 35;

            numOfLight--;
            yield return new WaitForSecondsRealtime(Random.Range(1.5f, 3.5f));
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
            aiScript.speed = 550f;

            //Setting Monster Attack Damage
            MonsterDamage damageScript = monsterSpawn.GetComponent<MonsterDamage>();
            damageScript.damageAmount = 3;

            //Setting Monster Health and Resilience
            MonsterHealth healthScript = monsterSpawn.GetComponent<MonsterHealth>();
            healthScript.health = 75;
            healthScript.baseDamageTaken = 35;

            //Setting Monster Sprite
            SpriteRenderer spriteRenderer = monsterSpawn.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = medMonsterSprite;

            numOfMed--;
            yield return new WaitForSecondsRealtime(Random.Range(3.5f, 5f));
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
            aiScript.speed = 450f;

            //Setting Monster Attack Damage
            MonsterDamage damageScript = monsterSpawn.GetComponent<MonsterDamage>();
            damageScript.damageAmount = 4;

            //Setting Monster Health and Resilience
            MonsterHealth healthScript = monsterSpawn.GetComponent<MonsterHealth>();
            healthScript.health = 100;
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
