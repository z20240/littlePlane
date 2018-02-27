﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;

public class gamePlayManager : MonoBehaviour {

    public GameObject gameOverTitle;
    private JsonData gameConfig;
    private int stage = 1; // 現在的關卡
    private bool bossFlag = false; // boss flag
    private bool playerDead = false;
    private int bossDeadAwakeTime;

    public bool BossFlag { get { return bossFlag; } set { bossFlag = value; } }
    public bool PlayerDead { get { return playerDead; } set { playerDead = value; } }
    public int BossDeadAwakeTime { get { return bossDeadAwakeTime; } set { bossDeadAwakeTime = value; } }

    void Awake() {
        // 關閉 gameOver 的標示
        gameOverTitle.SetActive(false);
        // 讀取 設定
        LocalFile lf = new LocalFile();
        gameConfig = lf.LoadLocalFile("Assets", "config.json");

        // 設定第一隻 boss 的甦醒時間
        int now = (int)(System.DateTime.Now.AddHours ( -8 ) - new System.DateTime( 1970, 1, 1, 0, 0, 0 ) ).TotalSeconds;
        bossDeadAwakeTime = now + (int)gameConfig["boss_create_freq"];
    }
	void Start () {
	}
	// Update is called once per frame
	void Update () {
        if (playerDead && Input.GetKey(KeyCode.Space)) {
            playerDead = false;
            SceneManager.LoadScene("gameStartUI");
        }
	}
    public JsonData getGameConfig() { return gameConfig; }
    public int getStage() { return stage ;}
    public void addStage() {
        stage++ ;
        gameConfig["mob_create_freq"] = (((int)gameConfig["mob_create_freq"] - stage*0.5 > 3)) ? (int)gameConfig["mob_create_freq"] - stage*0.5 : 3;
        gameConfig["mob_bullet_speed"] = (double)gameConfig["mob_bullet_speed"] + stage * 0.5;
        gameConfig["mob"]["mob_normal"]["hp"] = (int)gameConfig["mob"]["mob_normal"]["hp"] + 1;
        gameConfig["mob"]["mob_normal"]["speed"] = (double)gameConfig["mob"]["mob_normal"]["speed"] + 0.01;

        gameConfig["mob"]["mob_mid"]["hp"] = (int)gameConfig["mob"]["mob_mid"]["hp"] + 1;
        gameConfig["mob"]["mob_mid"]["speed"] = (double)gameConfig["mob"]["mob_mid"]["speed"] + 0.01;
        gameConfig["mob"]["mob_mid"]["fireRate"] = ((double)gameConfig["mob"]["mob_mid"]["fireRate"] - 0.2 > 0.1) ?
            (float)((double)gameConfig["mob"]["mob_mid"]["fireRate"] - 0.2) : 0.1 ;

        gameConfig["mob"]["mob_hard"]["hp"] = (int)gameConfig["mob"]["mob_hard"]["hp"] + 1;
        gameConfig["mob"]["mob_hard"]["speed"] = (double)gameConfig["mob"]["mob_hard"]["speed"] + 0.01;
        gameConfig["mob"]["mob_hard"]["fireRate"] = ((double)gameConfig["mob"]["mob_hard"]["fireRate"] - 0.2 > 0.1) ?
            (float)((double)gameConfig["mob"]["mob_hard"]["fireRate"] - 0.2) : 0.1 ;

        gameConfig["mob"]["mob_boss"] = (int)gameConfig["mob"]["mob_boss"] + 10;
    }

}
