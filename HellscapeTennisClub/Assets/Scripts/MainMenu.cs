using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public PlayerController playerScript;
    public WaveManager waveScript;
    public GameObject healthBar, chargeBar;

    public void StartGame()
    {
        playerScript.movementAllowed = true;
        waveScript.WaveInitiation();
        healthBar.SetActive(true);
        chargeBar.SetActive(true);
    }
}
