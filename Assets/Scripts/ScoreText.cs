using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();

        GameManager.OnScoreUpdated += OnScoreChange;
    }

    private void OnDestroy()
    {
        GameManager.OnScoreUpdated -= OnScoreChange;
    }

    private void OnScoreChange()
    {
        text.text = "Score: " + GameManager.Score;
    }
}
