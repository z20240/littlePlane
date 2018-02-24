using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用UI

public class socreBoardControl : MonoBehaviour {

    public Text ScoreText; //宣告一個ScoreText的text
    public int Score = 0; // 宣告一整數 Score
    public static socreBoardControl Instance; // 設定Instance，讓其他程式能讀取GameFunction裡的東西

    // Use this for initialization
    void Start () {
        Instance = this;
    }

    // Update is called once per frame
    void Update () {

    }

    public void AddScore () {
        Score += 10; //分數+10
        ScoreText.text = "Score : " + Score; // 更改ScoreText的內容

    }
}