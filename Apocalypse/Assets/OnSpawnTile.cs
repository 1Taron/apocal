using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSpawnTile : MonoBehaviour
{
    public Text battle_info;
    public void TurnOnSpawnTiles()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }
        AnimalSpawnManager.tileC();
    }

    public void TurnOnSpawnTiles_Gazelle()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileE();
    }

    public void TurnOnSpawnTiles_Hyena()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileF();
    }

    public void TurnOnSpawnTiles_Croco()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileG();
    }

    public void TurnOnSpawnTiles_Cheetah()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileH();
    }

    public void TurnOnSpawnTiles_Hippo()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileI();
    }

    public void TurnOnSpawnTiles_Rhino()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileJ();
    }

    public void TurnOnSpawnTiles_Snake()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileK();
    }

    public void TurnOnSpawnTiles_Lion()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileL();
    }

    public void TurnOnSpawnTiles_Eagle()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileN();
    }
    public void TurnOnSpawnTiles_Giraffe()
    {
        GameObject.Find("AnimalCreate_pn").SetActive(false);

        if (battle_info.text == "Player1 Turn")
        {
            Tile.tileA();
        }
        else if (battle_info.text == "Player2 Turn")
        {
            Tile.tileA2();
        }

        AnimalSpawnManager.tileM();
    }
}
