using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnimalCreate2 : MonoBehaviour
{
    public GameObject Animal01;
    public GameObject Animal02;
    public GameObject Animal03;
    public GameObject Animal04;
    public GameObject Animal05;
    public GameObject Animal06;
    public GameObject Animal07;
    public GameObject Animal08;
    public GameObject Animal09;
    public GameObject Animal10;
    public GameObject Animal11;
    public Camera C;

    float xpos, ypos;
    string strtile;
    void Start()
    {
        Tile.tileD();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = C.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {

                strtile = hit.collider.gameObject.name;
                switch (strtile)
                {
                    case "Tile 1 27":
                        CreateAnimal_();
                        break;
                    case "Tile 1 28":
                        CreateAnimal_();
                        break;
                    case "Tile 1 29":
                        CreateAnimal_();
                        break;
                    case "Tile 1 30":
                        CreateAnimal_();
                        break;
                    case "Tile 1 31":
                        CreateAnimal_();
                        break;
                    case "Tile 2 27":
                        CreateAnimal_();
                        break;
                    case "Tile 2 28":
                        CreateAnimal_();
                        break;
                    case "Tile 2 29":
                        CreateAnimal_();
                        break;
                    case "Tile 2 30":
                        CreateAnimal_();
                        break;
                    case "Tile 2 31":
                        CreateAnimal_();
                        break;
                    case "Tile 3 27":
                        CreateAnimal_();
                        break;
                    case "Tile 3 28":
                        CreateAnimal_();
                        break;
                    case "Tile 3 29":
                        CreateAnimal_();
                        break;
                    case "Tile 3 30":
                        CreateAnimal_();
                        break;
                    case "Tile 3 31":
                        CreateAnimal_();
                        break;
                    case "Tile 4 27":
                        CreateAnimal_();
                        break;
                    case "Tile 4 28":
                        CreateAnimal_();
                        break;
                    case "Tile 4 29":
                        CreateAnimal_();
                        break;
                    case "Tile 4 30":
                        CreateAnimal_();
                        break;
                    case "Tile 4 31":
                        CreateAnimal_();
                        break;
                    case "Tile 5 27":
                        CreateAnimal_();
                        break;
                    case "Tile 5 28":
                        CreateAnimal_();
                        break;
                    case "Tile 5 29":
                        CreateAnimal_();
                        break;
                    case "Tile 5 30":
                        CreateAnimal_();
                        break;
                    case "Tile 5 31":
                        CreateAnimal_();
                        break;
                    default:
                        //WarningMessage();
                        break;
                }
            }
        }

    }
    /*void WarningMessage()
    {
        if (GameObject.Find(strtile).transform.Find("spawnable").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_gazelle").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_hyena").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_croco").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_cheetah").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_hippo").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_rhino").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_snake").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_lion").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_eagle").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_giraffe").gameObject.activeSelf == true)
        {
            Debug.Log("스폰 타일을 눌러주세요");
        }
    }*/

    void CreateAnimal_()
    {
        if (GameObject.Find(strtile).transform.Find("spawnable").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            Instantiate(Animal01, new Vector3(xpos, ypos, -2), Quaternion.identity);
            Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_gazelle").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _GazelleCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_hyena").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _HyenaCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_croco").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _CrocoCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_cheetah").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _CheetahCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_hippo").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _HippoCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_rhino").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _RhinoCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_snake").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _SnakeCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_lion").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _LionCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_eagle").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _EagleCreate(); Tile.tileB(); Tile.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_giraffe").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _GiraffeCreate(); Tile.tileB(); Tile.tileD();
        }
    }

    void _RabbitCreate()
    {
        Instantiate(Animal01, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }

    void _GazelleCreate()
    {
        Instantiate(Animal02, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _HyenaCreate()
    {
        Instantiate(Animal03, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _CrocoCreate()
    {
        Instantiate(Animal04, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _CheetahCreate()
    {
        Instantiate(Animal05, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _HippoCreate()
    {
        Instantiate(Animal06, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _RhinoCreate()
    {
        Instantiate(Animal07, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _SnakeCreate()
    {
        Instantiate(Animal08, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _LionCreate()
    {
        Instantiate(Animal09, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _EagleCreate()
    {
        Instantiate(Animal10, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
    void _GiraffeCreate()
    {
        Instantiate(Animal11, new Vector3(xpos, ypos, -2), Quaternion.identity);
    }
}
