using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject Infopn, Infopn2, Infopn3;

    public void InfoOpen()
    {
        Infopn.SetActive(true);
    }

    public void InfoClose()
    {
        Infopn.SetActive(false);
    }

    public void InfoClose2()
    {
        Infopn2.SetActive(false);
    }

    public void InfoClose3()
    {
        Infopn3.SetActive(false);
    }

    public void Nextpage()
    {
        if(Infopn.activeSelf == true)
        {
            Infopn.SetActive(false);
            Infopn2.SetActive(true);
        }
        else if(Infopn2.activeSelf == true)
        {
            Infopn2.SetActive(false);
            Infopn3.SetActive(true);
        }
    }

    public void Lastpage()
    {
        if(Infopn2.activeSelf == true)
        {
            Infopn.SetActive(true);
            Infopn2.SetActive(false);
        }
        else if(Infopn3.activeSelf == true)
        {
            Infopn2.SetActive(true);
            Infopn3.SetActive(false);
        }
    }
}
