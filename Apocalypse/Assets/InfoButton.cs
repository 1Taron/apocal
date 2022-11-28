using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject Infopn;

    public void InfoOpen()
    {
        Infopn.SetActive(true);
    }

    public void InfoClose()
    {
        Infopn.SetActive(false);
    }
}
