using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreKeeper : MonoBehaviour
{
    public int CurrentHighscore = 0;
    public int score = 0;

    [SerializeField] GameObject HighscoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            CurrentHighscore = PlayerPrefs.GetInt("Highscore");
        }
        UpdateText();
    }

    // Update is called once per frame
     public void ScoreIncrease()
    {
        score += 100;
        if (score > CurrentHighscore)
        {
            CurrentHighscore = score;
        }

        UpdateText();
    }

    public void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        if (HighscoreText == null)
        {
            Debug.Log("Insert a highscore text into the Score Canvas please.");
            return;
        }
        HighscoreText.GetComponent<TextMeshProUGUI>().text = "Highscore: " + CurrentHighscore.ToString();
    }
}
