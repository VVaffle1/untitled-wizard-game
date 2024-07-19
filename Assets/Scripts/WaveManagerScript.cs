using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using System.Threading;

public class WaveManagerScript : MonoBehaviour
{
    public float waveNumber = 1;
    public TimerScript timerText;

    // Start is called before the first frame update
    public void Awake() 
    {
        StartCoroutine(FirstDisplayWave());
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Wave: " + waveNumber.ToString();
    }

    public IEnumerator DisplayWave()
    {
        yield return new WaitForSeconds(2f);
        timerText.StartTimer();
    }

    public IEnumerator FirstDisplayWave()
    {
        yield return new WaitForSeconds(5f);
        timerText.StartTimer();
    }
}
