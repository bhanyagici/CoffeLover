using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    private GameManager _gameManager;

    public int coffeeCount = 0;
    
    public float forwardSpeed;

    public List<GameObject> coffees;

    // Start is called before the first frame update
    void Start()
    {
        coffees = new List<GameObject>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }




    float firstTouchX;
    // Update is called once per frame
    void Update()
    {
        if (_gameManager.currentGameState != GameState.Start)
        {
            return;
        }

        for(int i =0; i < coffees.Count; i++)
        {
            coffees[i].transform.position = new Vector3(
                coffees[i].transform.position.x,
                coffees[i].transform.position.y,
                //Mat.Lerp:Objeyi yavaþ istenilen eksene sokmak için kullanýlýr.
                Mathf.Lerp(transform.position.z, coffees[i].transform.position.z, 0.01f*Time.deltaTime));
        }
        


        //Ýleri gönder
        Vector3 moveVector = new Vector3(-1 * forwardSpeed * Time.deltaTime, 0, 0);
        float different = 0;
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {//Hareket kodlarý
            float lastTouchX = Input.mousePosition.x;
            diff = lastTouchX - firstTouchX;
            moveVector += new Vector3(0, 0, diff * Time.deltaTime);
            firstTouchX = lastTouchX;//Ýlk týklanan nokta son týklanan nokta olmuþtur
        }
        transform.position += moveVector;

    }

      private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Collectible"))
        {
            other.transform.SetParent(transform);
            coffees.Add(other.gameObject);
            coffeeCount++;
        }
        else if (other.CompareTag("Finish"))
        {
            
            if (coffeeCount == 0)
            {
                _gameManager.EndGame();
            }
            else
            {
                coffees[coffees.Count - 1].SetActive(false);
                coffees.RemoveAt(coffees.Count - 1);
                coffeeCount--;
               
                if (coffeeCount == 0)
                {
                    _gameManager.EndGame();
                }

            }
           
        }
                
                
                
            
        
        }

    
}

