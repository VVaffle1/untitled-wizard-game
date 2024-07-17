using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = score.ToString();

    }

    // Update is called once per frame
     public void ScoreIncrease()
    {
        score += 10;
        Debug.Log(score);
        GetComponent<TextMeshProUGUI>().text = score.ToString();
    }
}