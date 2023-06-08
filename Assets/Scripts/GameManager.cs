using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState//Oyunun durumunu takip etmek i�in tan�mlad���m�z �zellikler
{
    Start,//Ba�lad� m�
    Pause,//Men�de mi
    End//Bitti mi
}
public class GameManager : MonoBehaviour
{

    private LevelManager _levelmanager;//LevelManager'�n bir referans� al�n�yor.

    public GameState currentGameState;//GameState de�i�keni tan�mlan�yor.

    UIManager _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        _levelmanager = GetComponent<LevelManager>();//Ba�lang��ta LevelManager bulunuyor.
        _uiManager = GameObject.FindWithTag("MainUI").GetComponent<UIManager>();
        currentGameState = GameState.Pause;
    }
    public void StartGame()//StartGame ad�nda bir fonksiyon olu�turuluyor.
    {
        currentGameState = GameState.Start;//Bu fonksiyon oyunun State'tini Start yaps�n
        _uiManager.UpdateLevelText(_levelmanager.currentLevel);
        _levelmanager.StartLevel();//_levelManager�n'da StartLevel fonksiyonunu �a��rs�n
    }
    public void StartNextGame()
    {
        currentGameState = GameState.Start;       
        _levelmanager.StartNextLevel();
        _uiManager.UpdateLevelText(_levelmanager.currentLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))//Aray�z hen�z olmad��� i�in S tu�una bas�ld���nda oyunun ba�lat�lmas� sa�lans�n.
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
        Debug.Log("Level tamamland�");
    }
}
