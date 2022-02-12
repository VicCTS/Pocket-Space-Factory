using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsController : MonoBehaviour
{
    public TextMeshProUGUI totalTime;
    public TextMeshProUGUI maxScore;
    public TextMeshProUGUI maxLevel;

    private float minutes; 
    private float seconds;
    private string timer;

    private void Awake() {

        /*GameObject.Find("Tme played number").GetComponent<TextMeshPro>();
        GameObject.Find("Max score number").GetComponent<TextMeshPro>();
        GameObject.Find("Max level number").GetComponent<TextMeshPro>();*/
        minutes = Mathf.FloorToInt(PlayerPrefs.GetFloat("totalTime", 0) / 60F);
        seconds = Mathf.FloorToInt(PlayerPrefs.GetFloat("totalTime", 0) - minutes * 60);
        timer = string.Format("{0:0}:{1:00}", minutes, seconds);

        totalTime.text = timer;
        maxScore.text = PlayerPrefs.GetInt("maxScore", 0).ToString();
        maxLevel.text = PlayerPrefs.GetInt("maxLevel", 0).ToString();

        
    }
}
