using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TMP_Text uiText;

    void Start()
    {
        uiText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        uiText.text = score.ToString("#,0"); // This 0 is a zero!            
    }
}
