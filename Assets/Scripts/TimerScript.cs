using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] public float timerCountdown = 45;
    public WaveManagerScript waveDisplay;
    [SerializeField] private bool canCount = false;
    [SerializeField] GameObject waveTextBox;

    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = timerCountdown.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = timerCountdown.ToString("F0");

        if(timerCountdown <= 0)
        {
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (allEnemies.Length > 0) { return; }
            foreach (GameObject obj in allEnemies)
            {
                Destroy(obj);
            }
            GameObject[] allCrystals = GameObject.FindGameObjectsWithTag("Crystal");
            foreach (GameObject obj in allCrystals)
            {
                Destroy(obj);
            }
            waveDisplay.waveNumber++;
            timerCountdown = 45;
            canCount = false;
            waveTextBox.SetActive(true);
            StartCoroutine(waveDisplay.DisplayWave());
        }

        if(canCount == true && timerCountdown > 0)
        {
            timerCountdown -= Time.deltaTime;
        }
    }
    public void StartTimer()
    {
            waveTextBox.SetActive(false);
            canCount= true;
       
    }
}
