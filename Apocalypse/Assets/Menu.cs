using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject createMenu;
    // Start is called before the first frame update
    public void AnimalCreate_btn_clicked()
    {
        createMenu.SetActive(true);
    }

    // Update is called once per frame
    public void AnimalCreateback_btn_clicked()
    {
        createMenu.SetActive(false);
    }
}
