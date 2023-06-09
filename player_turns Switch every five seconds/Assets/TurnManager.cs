﻿using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public Text currentPlayerText;
    GameObject[] players;
    int currentPlayer;
    float turnDuration = 5f;

    void Start()
    {
        currentPlayer = 0;
        players = new GameObject[transform.childCount];
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = transform.GetChild(i).gameObject;
        }
        
        // Call EndTurn() method every 'turnDuration' seconds
        InvokeRepeating("EndTurn", turnDuration, turnDuration);
    }

    public void EndTurn()
    {
        players[currentPlayer].GetComponent<Movement>().enabled = false;
        currentPlayer++;
        if (currentPlayer == players.Length)
        {
            currentPlayer = 0;
        }
        players[currentPlayer].GetComponent<Movement>().enabled = true;
        currentPlayerText.text = "Current Player: " + players[currentPlayer].name;
    }
}
