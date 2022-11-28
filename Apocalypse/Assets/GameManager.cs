using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Slider player1hp, player2hp;

    void Update()
    {
        if(player1hp.value == 0)
        {
            SceneManager.LoadScene("Player2Win");
        }
        else if(player2hp.value == 0)
        {
            SceneManager.LoadScene("Player1Win");
        }
    }
}
