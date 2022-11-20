using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turn : MonoBehaviour
{
    public bool player1_turn;
    public Text battle_info;
    public GameObject Player01;
    public GameObject Player02;
    public Text cost1;
    public Text cost2;
    

    void Start()
    {
        player1_turn = true;
        Debug.Log("<color=white>Start()</color>" + player1_turn);
        Player02.SetActive(false);
        Info();
        cost1.text = "10";
        cost2.text = "10";
    }

    void Update()
    {
        

    }
    public void OnClickEndTurn()
    {
        TurnChanged(player1_turn);
    }

    private bool TurnChanged(bool turn)
    {
        turn = !turn;
        player1_turn = turn;
        Info();
        return turn;
    }

    void Info()
    {
        Debug.Log("<color=white>Info()</color>" + player1_turn);

        if (player1_turn == true)
        {
            battle_info.text = "Player1 Turn";
            Player01.SetActive(true);
            Player02.SetActive(false);
        }
        else
        {
            battle_info.text = "Player2 Turn";
            Player01.SetActive(false);
            Player02.SetActive(true);
        }
    }
}
