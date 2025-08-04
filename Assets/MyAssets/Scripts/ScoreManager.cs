using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    //public static ScoreManager Instance;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro accuracyText;
    public TMPro.TextMeshPro comboText;
    public GameObject gameOverMenu;
    public List<GameObject> deactivateItems = new List<GameObject>();
    float accuracy;
    int combo = 0;
    int score = 0;
    int bestCombo = 0;
    int missSequence = 0;
    int notes = 0;

    public void Hit()
    {
        notes++;
        score++;
        combo += 1;
        missSequence = 0;

        if (combo > bestCombo)
        {
            bestCombo = combo;
        }
    }
    public void Miss()
    {
        combo = 0;
        notes++;
        missSequence++;
        if (missSequence >= 5)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        accuracy = (float)score/(float) notes;

        accuracyText.text = (accuracy * 100f).ToString("F1") + "%";  // F1: uma casa decimal
        comboText.text = combo.ToString();
        scoreText.text = score.ToString();

        for (int i = 0; i < deactivateItems.Count; i++)
        {
            if (deactivateItems[i] != null)
            {
                deactivateItems[i].SetActive(false);
            }   
        }

        gameOverMenu.SetActive(true);
    }
}
