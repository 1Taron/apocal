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
    public Text Player1_MoveCost;
    public Text Player2_MoveCost;
    public List<GameObject> FoundObjects1;
    public List<GameObject> FoundObjects2;
    public List<GameObject> FoundObjects3;
    public List<GameObject> FoundObjects4;
    public List<GameObject> FoundObjects5;
    public List<GameObject> FoundObjects6;
    public GameObject grass;
    public float shortDis1 = 2.2f;
    int a;
    int cost_;
    string cost;
    string gr;

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
        Player1_MoveCost.text = "10";
        Player2_MoveCost.text = "10";
    }

    private bool TurnChanged(bool turn)
    {
        for(int x = 1; x<=41; x++){
            for(int y = 1; y<=31; y++){
                GameObject.Find($"Tile {x} {y}").transform.Find("movehighlight").gameObject.SetActive(false);
            }
        }
        if(battle_info.text == "Player1 Turn"){
            FoundObjects2 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Grass"));
            shortDis1 = 2.2f;
            FoundObjects1 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rabbit"));            
            foreach (GameObject found1 in FoundObjects1){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                Debug.Log(shortDis1);
                gr = grass.name;
                if(shortDis1 < 2.0001){
                cost = cost1.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost1.text = cost;
                Destroy(grass);
                }
                
                
                
            }
            shortDis1 = 2.2f;
            FoundObjects3 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Gazelle"));            
            foreach (GameObject found1 in FoundObjects3){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost1.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 2;
                cost= cost_.ToString();
                cost1.text = cost;
                }
            }
            shortDis1 = 2.2f;
            FoundObjects4 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rhino"));            
            foreach (GameObject found1 in FoundObjects4){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost1.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost1.text = cost;
                }
            }
            shortDis1 = 2.2f;
            FoundObjects5 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Giaffe"));            
            foreach (GameObject found1 in FoundObjects5){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost1.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost1.text = cost;
                }
            }
            shortDis1 = 2.2f;
            FoundObjects6 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Hippo"));            
            foreach (GameObject found1 in FoundObjects6){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost1.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost1.text = cost;
                }
            }    
        }
        if(battle_info.text == "Player2 Turn"){
            FoundObjects2 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Grass"));
            shortDis1 = 2.2f;
            FoundObjects1 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rabbit2"));            
            foreach (GameObject found1 in FoundObjects1){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost2.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost2.text = cost;
                }
            }
            shortDis1 = 2.2f;
            FoundObjects3 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Gazelle2"));            
            foreach (GameObject found1 in FoundObjects3){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost2.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 2;
                cost= cost_.ToString();
                cost2.text = cost;
                }
            }
            shortDis1 = 2.2f;
            FoundObjects4 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Rhino2"));            
            foreach (GameObject found1 in FoundObjects4){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                if(shortDis1 < 2.01){
                Destroy(grass);
                cost = cost2.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost2.text = cost;
                }
            }
            shortDis1 = 2.2f;
            FoundObjects5 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Giaffe2"));            
            foreach (GameObject found1 in FoundObjects5){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                Destroy(grass);
                cost = cost2.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost2.text = cost;
            }
            shortDis1 = 2.2f;
            FoundObjects6 = new List<GameObject>(GameObject.FindGameObjectsWithTag("Hippo2"));            
            foreach (GameObject found1 in FoundObjects6){                   
                foreach (GameObject found2 in FoundObjects2)
                {
                    float Distance = Vector3.Distance(found1.transform.position, found2.transform.position); 
                    if (Distance < shortDis1) // 위에서 잡은 기준으로 거리 재기
                    {
                        grass = found2;
                        shortDis1 = Distance;
                    }
                }
                Destroy(grass);
                cost = cost2.text;
                cost_ = int.Parse(cost);
                cost_ = cost_ + 1;
                cost= cost_.ToString();
                cost2.text = cost;
            }    
        }    
            
        
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
