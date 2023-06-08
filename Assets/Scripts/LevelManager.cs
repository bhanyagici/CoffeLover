using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels;

    public int currentLevel;
    private Player _player;
    private Vector3 playerDefaultPosition;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        playerDefaultPosition = _player.transform.position;
    }
    public void StartLevel()
    {
        levels[currentLevel % levels.Length].gameObject.SetActive(true);      
        _player.transform.position = playerDefaultPosition;
    }
    
    public void StartNextLevel()
    {
        levels[currentLevel % levels.Length].ResetLevel();//Level deðeri arttýrýlmadan level resetleniyor.
        levels[currentLevel%levels.Length].gameObject.SetActive(false);
        currentLevel++;//Level deðeri arttýrýlýyor.
        StartLevel();
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.Save();
    }

    public void EndLevel()
    {
        
    }
    
    






}
