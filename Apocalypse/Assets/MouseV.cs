using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MouseV : MonoBehaviour
{
    public List<GameObject> FoundObjects;
    public GameObject tile;
    public float shortDis;
    Vector2 MousePosition;
    Camera C;
    public GameObject clone;
    public GameObject AnimalCreate;
    public GameObject AnimalCreate2;
    public Text battle_info;
    public Text cost1;
    public Text cost2;
    int xp, yp;
    int cost_1;
    int cost_2;
    string cost_;
    void Start()
    {
        C = GameObject.Find("Main Camera").GetComponent<Camera>();
        

    }

    // Update is called once per frame else if(hit.collider.gameObject.name == "Grass")
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 pos = C.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                
                Debug.Log(hit.collider.gameObject.name);
                bool clonecheck = hit.collider.gameObject.name.Contains("Clone");
                bool clonecheck2 = hit.collider.gameObject.name.Contains("Tile");
                bool clonecheck3 = hit.collider.gameObject.name.Contains("Grass");
                if(clonecheck == true){
                    FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Tile"));
                    shortDis = Vector3.Distance(hit.collider.gameObject.transform.position, FoundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기  
                    tile = FoundObjects[0]; // 첫번째를 먼저  
                    foreach (GameObject found in FoundObjects)
                    {
                        float Distance = Vector3.Distance(hit.collider.gameObject.transform.position, found.transform.position); 
                        if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
                        {
                            tile = found;
                            shortDis = Distance;
                        }
                    }
                    Debug.Log(tile.name);
                    if(hit.collider.gameObject.name == "Rabiit(Clone)"){
                        if(battle_info.text == "Player1 Turn")
                        {
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                            clone = hit.collider.gameObject;
                            string name = tile.name;
                            char sp = ' ';
                            string[] spstring = name.Split(sp);
                        
                            xp = int.Parse(spstring[1]);
                            yp = int.Parse(spstring[2]);
                            int perimeter = 1;
                            if(yp % 2 == 1)
                            {
                                for(int x = xp - perimeter; x <= xp; x++)
                                {                            
                                    for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                    {
                                        if(GameObject.Find($"Tile {x} {y}") != null)
                                        {
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);    
                                        }                            
                                    }
                                }
                                if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            else if(yp % 2 == 0 &&  yp != 0)
                            {
                                for(int x = xp; x <= xp + perimeter; x++)
                                {                            
                                    for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                    {
                                        if(GameObject.Find($"Tile {x} {y}") != null)
                                        {
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);    
                                        }                            
                                    }
                                }
                                if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn")
                        {
                            if(clone.name == "Rabbit2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Snake2(Clone)" || clone.name == "Croco2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Hyena2(Clone)"
                            || clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;
                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 2;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Giaffe2(Clone)" || clone.name == "Gazelle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                        }
                                    
                                    
                    }
                    else if(hit.collider.gameObject.name == "Rabbit2(Clone)"){
                        if(battle_info.text == "Player1 Turn")
                        {
                            if(clone.name == "Rabiit(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Snake2(Clone)" || clone.name == "Croco2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Hyena2(Clone)"
                            || clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 2;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Giaffe2(Clone)" || clone.name == "Gazelle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn")
                        {                    
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            } 
                            clone = hit.collider.gameObject;
                            string name = tile.name;
                            char sp = ' ';
                            string[] spstring = name.Split(sp);
                        
                            xp = int.Parse(spstring[1]);
                            yp = int.Parse(spstring[2]);
                            int perimeter = 1;
                            if(yp % 2 == 1)
                            {
                                for(int x = xp - perimeter; x <= xp; x++)
                                {                            
                                    for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                    {
                                        if(GameObject.Find($"Tile {x} {y}") != null)
                                        {
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);    
                                        }                            
                                    }
                                }
                                if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            else if(yp % 2 == 0 &&  yp != 0)
                            {
                                for(int x = xp; x <= xp + perimeter; x++)
                                {                            
                                    for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                    {
                                        if(GameObject.Find($"Tile {x} {y}") != null)
                                        {
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);    
                                        }                            
                                    }
                                }
                                if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }  
                        }
                                    
                                  
                    }
                    else if(hit.collider.gameObject.name == "Snake(Clone)"){
                        if(battle_info.text == "Player1 Turn")
                        {
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }
                        else if(battle_info.text == "Player2 Turn")
                        {
                            if(clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Croco2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Rhino2(Clone)" || clone.name == "Hyena2(Clone)"
                             || clone.name == "Giaffe2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    Destroy(clone);                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                            else if(clone.name == "Rabbit2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 1;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                }
                            }
                        }            
                                    
                    }
                    else if(hit.collider.gameObject.name == "Snake2(Clone)"){
                        if(battle_info.text == "Player1 Turn")
                        {
                            if(clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Croco(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Rhino(Clone)" || clone.name == "Hyena(Clone)"
                             || clone.name == "Giaffe(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    Destroy(clone);                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                            else if(clone.name == "Rabiit(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 1;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn")
                        {
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }            
                                    
                    }
                    else if(hit.collider.gameObject.name == "Croco(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Croco2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Hippo2(Clone)" || clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 2;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabbit2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Gazelle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)" || clone.name == "Rhino2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Croco2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Croco(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Hippo(Clone)" || clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 2;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabbit(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Gazelle(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)" || clone.name == "Rhino(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Hippo(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Hippo2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 5;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabbit2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Rhino2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Hippo2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Hippo(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 5;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabiit(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Rhino(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Rhino(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Rhino2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)" || clone.name == "Hippo2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 4;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabbit2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Rhino2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Rhino(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)" || clone.name == "Hippo(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 4;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabiit(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 2;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 1; x <= xp + 1; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++)
                            {
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Hyena(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 4;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-2} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-2} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Hyena2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 1;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabbit2(Clone)" || clone.name == "Gazelle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)" || clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Hyena2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Hyena(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 1;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabiit(Clone)" || clone.name == "Gazelle(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)" || clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 4;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-2} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-2} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Giaffe(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 4;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-2} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-2} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Giaffe2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 6;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Rabbit2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Giaffe2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Giaffe(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 6;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Rabiit(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 4;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-2} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-2} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Gazelle(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 4;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-2} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-2} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Gazelle2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 6;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabbit2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Gazelle2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Gazelle(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 6;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rabiit(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Rhino(Clone)" || clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 4;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 2; x <= xp + 2; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-2} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-2} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+3} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+3} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Lion(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 6;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 3; x <= xp + 3; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){
                                if(GameObject.Find($"Tile {xp-4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 3; x <= xp + 3; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Lion2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Eagle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 3;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Rabbit2(Clone)" || clone.name == "Cheetah2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Lion2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Lion(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Eagle(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 3;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Rabiit(Clone)" || clone.name == "Cheetah(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 6;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 3; x <= xp + 3; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){
                                if(GameObject.Find($"Tile {xp-4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 3; x <= xp + 3; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 2; y <= yp + 2; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+5} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+5} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){                                
                                if(GameObject.Find($"Tile {xp+4} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+4} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Eagle(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 10;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++){
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 6; y <= yp + 6; y++){
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 6; y <= yp + 6; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){                                
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){                                
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){                                
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){                                
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){                                
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Eagle2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 5;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Rabbit2(Clone)" || clone.name == "Cheetah2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Eagle2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Eagle(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 5;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Rabiit(Clone)" || clone.name == "Cheetah(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 10;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++){
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 6; y <= yp + 6; y++){
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 6; y <= yp + 6; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){                                
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){                                
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){                                
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){                                
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){                                
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }        
                    }
                    else if(hit.collider.gameObject.name == "Cheetah(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 10;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++){
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 6; y <= yp + 6; y++){
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 6; y <= yp + 6; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){                                
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){                                
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){                                
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){                                
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){                                
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            if(clone.name == "Cheetah2(Clone)" || clone.name == "Snake2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;

                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 4;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino2(Clone)" || clone.name == "Gazelle2(Clone)" || clone.name == "Rabbit2(Clone)" || clone.name == "Hyena2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Croco2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }            
                    }
                    else if(hit.collider.gameObject.name == "Cheetah2(Clone)"){
                        if(battle_info.text == "Player1 Turn"){
                            if(clone.name == "Cheetah(Clone)" || clone.name == "Snake(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    
                                    
                                    Destroy(clone);
                                    Destroy(hit.collider.gameObject);
                                }
                            }
                            else if(clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;

                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 4;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                    
                                }
                            }
                            else if(clone.name == "Rhino(Clone)" || clone.name == "Gazelle(Clone)" || clone.name == "Rabiit(Clone)" || clone.name == "Hyena(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Croco(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(clone);
                                    
                                }
                            }
                            else if(clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                    Destroy(hit.collider.gameObject);
                                    
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn"){
                            for(int x = 1; x<=41; x++){
                                for(int y = 1; y<=31; y++){
                                    GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                }
                            }
                        clone = hit.collider.gameObject;
                        string name = tile.name;
                        char sp = ' ';
                        string[] spstring = name.Split(sp);
                        
                        xp = int.Parse(spstring[1]);
                        yp = int.Parse(spstring[2]);
                        int perimeter = 10;
                        if(yp % 2 == 1)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){
                                if(GameObject.Find($"Tile {xp-perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++){
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 6; y <= yp + 6; y++){
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp+perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp+perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }
                        else if(yp % 2 == 0 &&  yp != 0)
                        {
                            for(int x = xp - 5; x <= xp + 5; x++)
                            {                            
                                for(int y = yp - perimeter; y <= yp + perimeter; y++)
                                {
                                    if(GameObject.Find($"Tile {x} {y}") != null)
                                    {
                                        GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                    }                                
                                }
                            }
                            for(int y = yp - 8; y <= yp + 8; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                                                
                            }
                            for(int y = yp - 6; y <= yp + 6; y++)
                            {                                
                                if(GameObject.Find($"Tile {xp-7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }                                
                            }
                            for(int y = yp - 4; y <= yp + 4; y++){                                
                                if(GameObject.Find($"Tile {xp-8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 2; y <= yp + 2; y++){                                
                                if(GameObject.Find($"Tile {xp-9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp-9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 9; y <= yp + 9; y++){                                
                                if(GameObject.Find($"Tile {xp+6} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+6} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 7; y <= yp + 7; y++){                                
                                if(GameObject.Find($"Tile {xp+7} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+7} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 5; y <= yp + 5; y++){                                
                                if(GameObject.Find($"Tile {xp+8} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+8} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 3; y <= yp + 3; y++){                                
                                if(GameObject.Find($"Tile {xp+9} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+9} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            for(int y = yp - 1; y <= yp + 1; y++){                                
                                if(GameObject.Find($"Tile {xp+perimeter} {y}") != null)
                                {
                                    GameObject.Find($"Tile {xp+perimeter} {y}").transform.Find("movehighlight").gameObject.SetActive(true);
                                }
                            }
                            if(GameObject.Find($"Tile {xp-perimeter} {yp}") != null)
                            {
                                GameObject.Find($"Tile {xp-perimeter} {yp}").transform.Find("movehighlight").gameObject.SetActive(true);
                            }
                        }             
                        }            
                    }
                                    
                                    
                    
                }
                else if(clonecheck2 == true)
                {
                    if(GameObject.Find(hit.collider.gameObject.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                    {
                    float xpos = hit.collider.gameObject.transform.position.x;
                    float ypos = hit.collider.gameObject.transform.position.y;
                    Debug.Log(xpos);
                    clone.transform.position=new Vector3(xpos,ypos,-2);
                    for(int x = 1; x<=41; x++){
                        for(int y = 1; y<=31; y++){
                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                        }
                    }

                    
                    }
                }
                else if(clonecheck3 == true)
                {
                    if(battle_info.text == "Player1 Turn")
                        {
                            if(clone.name == "Rabiit(Clone)" || clone.name == "Hippo(Clone)" || clone.name == "Rhino(Clone)" || clone.name == "Giaffe(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;
                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 1;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                }
                            }
                            else if(clone.name == "Gazelle(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost1.text;
                                    cost_1 = int.Parse(cost_);
                                    cost_1 = cost_1 + 2;
                                    cost_= cost_1.ToString();
                                    cost1.text = cost_;
                                }
                            }
                            else if(clone.name == "Snake(Clone)" || clone.name == "Croco(Clone)" || clone.name == "Hyena(Clone)"
                            || clone.name == "Lion(Clone)" || clone.name == "Eagle(Clone)" || clone.name == "Cheetah(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                }
                            }
                        }
                        else if(battle_info.text == "Player2 Turn")
                        {
                            if(clone.name == "Rabbit2(Clone)" || clone.name == "Hippo2(Clone)" || clone.name == "Rhino2(Clone)" || clone.name == "Giaffe2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;
                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 1;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                }
                            }
                            else if(clone.name == "Gazelle2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }
                                    Destroy(hit.collider.gameObject);
                                    cost_ = cost2.text;
                                    cost_2 = int.Parse(cost_);
                                    cost_2 = cost_2 + 2;
                                    cost_= cost_2.ToString();
                                    cost2.text = cost_;
                                }
                            }
                            else if(clone.name == "Snake2(Clone)" || clone.name == "Croco2(Clone)" || clone.name == "Hyena2(Clone)"
                            || clone.name == "Lion2(Clone)" || clone.name == "Eagle2(Clone)" || clone.name == "Cheetah2(Clone)")
                            {
                                if(GameObject.Find(tile.name).transform.Find("movehighlight").gameObject.activeSelf == true)
                                {
                                    float xpos = hit.collider.gameObject.transform.position.x;
                                    float ypos = hit.collider.gameObject.transform.position.y;
                                    Debug.Log(xpos);
                                    clone.transform.position=new Vector3(xpos,ypos,-2);
                                    for(int x = 1; x<=41; x++){
                                        for(int y = 1; y<=31; y++){
                                            GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
                                        }
                                    }                              
                                }
                            }
                            
                        }
                }
                

            }
        }
    }
        //MousePosition = Input.mousePosition;

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(MousePosition);
}        //}


