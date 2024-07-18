using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] float timerCountdown = 60;
    public WaveManagerScript waveDisplay;
    [SerializeField] private bool canCount = false;
    [SerializeField] GameObject waveTextBox; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = timerCountdown.ToString("F0");

        if(timerCountdown <= 0)
        {
            GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject obj in allEnemies)
            {
                Destroy(obj);
            }
            waveDisplay.waveNumber++;
            timerCountdown = 45;
            canCount = false;
            waveTextBox.SetActive(true);
            waveDisplay.Awake();
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
