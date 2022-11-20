using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class AnimalCreate : MonoBehaviour
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
    public GameObject Animal12;
    public Camera C;

    float xpos, ypos;
    string strtile;

    public static Action eleSpawn1;
    private void Awake()
    {
        eleSpawn1 = () => { ElephantCreate(); };
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
                    case "Tile 41 1" :
                        CreateAnimal_();
                        break;
                    case "Tile 41 2":
                        CreateAnimal_();
                        break;
                    case "Tile 41 3":
                        CreateAnimal_();
                        break;
                    case "Tile 41 4":
                        CreateAnimal_();
                        break;
                    case "Tile 41 5":
                        CreateAnimal_();
                        break;
                    case "Tile 37 1":
                        CreateAnimal_();
                        break;
                    case "Tile 37 2":
                        CreateAnimal_();
                        break;
                    case "Tile 37 3":
                        CreateAnimal_();
                        break;
                    case "Tile 37 4":
                        CreateAnimal_();
                        break;
                    case "Tile 37 5":
                        CreateAnimal_();
                        break;
                    case "Tile 38 1":
                        CreateAnimal_();
                        break;
                    case "Tile 38 2":
                        CreateAnimal_();
                        break;
                    case "Tile 38 3":
                        CreateAnimal_();
                        break;
                    case "Tile 38 4":
                        CreateAnimal_();
                        break;
                    case "Tile 38 5":
                        CreateAnimal_();
                        break;
                    case "Tile 39 1":
                        CreateAnimal_();
                        break;
                    case "Tile 39 2":
                        CreateAnimal_();
                        break;
                    case "Tile 39 3":
                        CreateAnimal_();
                        break;
                    case "Tile 39 4":
                        CreateAnimal_();
                        break;
                    case "Tile 39 5":
                        CreateAnimal_();
                        break;
                    case "Tile 40 1":
                        CreateAnimal_();
                        break;
                    case "Tile 40 2":
                        CreateAnimal_();
                        break;
                    case "Tile 40 3":
                        CreateAnimal_();
                        break;
                    case "Tile 40 4":
                        CreateAnimal_();
                        break;
                    case "Tile 40 5":
                        CreateAnimal_();
                        break;
                    default:
                        //WarningMessage();
                        break;
                }
            }
        }
    
}
  
   void ElephantCreate()
    {
        Instantiate(Animal12, new Vector3(33.725f, 4.92f, -2), Quaternion.identity);
    }

    void CreateAnimal_()
    {
        if (GameObject.Find(strtile).transform.Find("spawnable").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _RabbitCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_gazelle").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _GazelleCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_hyena").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _HyenaCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_croco").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _CrocoCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_cheetah").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _CheetahCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_hippo").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _HippoCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_rhino").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _RhinoCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_snake").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _SnakeCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_lion").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _LionCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_eagle").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _EagleCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
        }
        else if (GameObject.Find(strtile).transform.Find("spawnable_giraffe").gameObject.activeSelf == true)
        {
            xpos = GameObject.Find(strtile).transform.position.x;
            ypos = GameObject.Find(strtile).transform.position.y;
            _GiraffeCreate(); Tile.tileB(); AnimalSpawnManager.tileD();
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
