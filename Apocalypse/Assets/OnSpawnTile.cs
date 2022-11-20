using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSpawnTile : MonoBehaviour
{
    public Text battle_info;
    public Text cost1;
    public Text cost2;
    int cost_;
    string cost;
    public GameObject Cannot;
    int a;
    public void CannotClick()
    {
        Cannot.SetActive(false);
    }
    public void Abc()
    {
        if (battle_info.text == "Player1 Turn")
        {
            cost = cost1.text;
            cost_ = int.Parse(cost);
            cost_ = cost_ - a;
            cost = cost_.ToString();
            cost1.text = cost;
            if (cost_ >= 0)
            {
                GameObject.Find("AnimalCreate_pn").SetActive(false);
                Tile.tileA();
            }
            else if (cost_ < 0)
            {
                Cannot.SetActive(true);
                cost = cost1.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + a;
                cost = cost_.ToString();
                cost1.text = cost;
            }
        }
        else if (battle_info.text == "Player2 Turn")
        {
            cost = cost2.text;
            cost_ = int.Parse(cost);
            cost_ = cost_ - a;
            cost = cost_.ToString();
            cost2.text = cost;
            if (cost_ >= 0)
            {
                GameObject.Find("AnimalCreate_pn").SetActive(false);
                Tile.tileA2();
            }
            else if (cost_ < 0)
            {
                Cannot.SetActive(true);
                cost = cost2.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + a;
                cost = cost_.ToString();
                cost2.text = cost;
            }
        }
    }
    public void TurnOnSpawnTiles()
    {
        a = 3;
        Abc();
        AnimalSpawnManager.tileC();
    }

    public void TurnOnSpawnTiles_Gazelle()
    {
        a = 6;
        Abc();

        AnimalSpawnManager.tileE();
    }

    public void TurnOnSpawnTiles_Hyena()
    {
        a = 2;
        Abc();

        AnimalSpawnManager.tileF();
    }

    public void TurnOnSpawnTiles_Croco()
    {
        a = 4;
        Abc();

        AnimalSpawnManager.tileG();
    }

    public void TurnOnSpawnTiles_Cheetah()
    {
        a = 10;
        Abc();

        AnimalSpawnManager.tileH();
    }

    public void TurnOnSpawnTiles_Hippo()
    {
        a = 8;
        Abc();

        AnimalSpawnManager.tileI();
    }

    public void TurnOnSpawnTiles_Rhino()
    {
        a = 6;
        Abc();

        AnimalSpawnManager.tileJ();
    }

    public void TurnOnSpawnTiles_Snake()
    {
        a = 8;
        Abc();

        AnimalSpawnManager.tileK();
    }

    public void TurnOnSpawnTiles_Lion()
    {
        a = 8;
        Abc();

        AnimalSpawnManager.tileL();
    }

    public void TurnOnSpawnTiles_Eagle()
    {
        a = 12;
        Abc();

        AnimalSpawnManager.tileN();
    }
    public void TurnOnSpawnTiles_Giraffe()
    {
        a = 8;
        Abc();

        AnimalSpawnManager.tileM();
    }
}
