using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState//Oyunun durumunu takip etmek için tanýmladýðýmýz özellikler
{
    Start,//Baþladý mý
    Pause,//Menüde mi
    End//Bitti mi
}
public class GameManager : MonoBehaviour
{

    private LevelManager _levelmanager;//LevelManager'ýn bir referansý alýnýyor.

    public GameState currentGameState;//GameState deðiþkeni tanýmlanýyor.

    UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _levelmanager = GetComponent<LevelManager>();//Baþlangýçta LevelManager bulunuyor.
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
        currentGameState = GameState.Pause;
    }
    public void StartGame()//StartGame adýnda bir fonksiyon oluþturuluyor.
    {
        currentGameState = GameState.Start;//Bu fonksiyon oyunun State'tini Start yapsýn
        _uiManager.UpdateLevelText(_levelmanager.currentLevel);
        _levelmanager.StartLevel();//_levelManagerýn'da StartLevel fonksiyonunu çaðýrsýn
    }
    public void StartNextGame()
    {
        currentGameState = GameState.Start;       
        _levelmanager.StartNextLevel();
        _uiManager.UpdateLevelText(_levelmanager.currentLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))//Arayüz henüz olmadýðý için S tuþuna basýldýðýnda oyunun baþlatýlmasý saðlansýn.
        {
            StartGame(); 
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartNextGame();
        }
    }

    public void EndGame()
    {
        _levelmanager.EndLevel();
        _uiManager.EndLevel();
        currentGameState = GameState.End;
        Debug.Log("Level tamamlandý");
    }
}
