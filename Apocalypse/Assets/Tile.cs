using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor, spawnColor, _riverColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight, _spawnable;

    public static Action tileA; public static Action tileM;
    public static Action tileB;public static Action tileC;public static Action tileD;public static Action tileE;
    public static Action tileF;public static Action tileG;public static Action tileH;public static Action tileI;
    public static Action tileJ;public static Action tileK;public static Action tileL;public static Action tileN;
    public static Action tileA2;

    private void Awake()
    {
        tileA = () => { ChangeSpawnColor(); }; tileM = () => { OnSpawnable_Giraffe(); };
        tileB = () => { ChangeBaseColor(); }; tileC = () => { OnSpawnable(); }; tileD = () => { OffSpawnable(); };
        tileE = () => { OnSpawnable_Gazelle(); }; tileF = () => { OnSpawnable_Hyena(); };tileG = () => { OnSpawnable_Croco(); };
        tileH = () => { OnSpawnable_Cheetah(); };tileI = () => { OnSpawnable_Hippo(); }; tileJ = () => { OnSpawnable_Rhino(); };
        tileK = () => { OnSpawnable_Snake(); }; tileL = () => { OnSpawnable_Lion(); };tileN = () => { OnSpawnable_Eagle(); };
        tileA2 = () => { ChangeSpawnColorPlayer2(); };
    }

    public void Init(int _colorValue)
    {
        switch (_colorValue)
        {
            case 1:
                _renderer.color = _baseColor;
                break;
            case 2:
                _renderer.color = _offsetColor;
                break;
            case 3:
                _renderer.color = spawnColor;
                break;
            case 4:
                _renderer.color = _riverColor;
                break;
        }
    }

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    void ChangeSpawnColor()
    {
        for (float x = 41; x > 36; x--)
        {
            for (float y = 1; y < 6; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().color = spawnColor;
            }
        }
    }

    void ChangeSpawnColorPlayer2()
    {
        for (float x = 1; x < 6; x++)
        {
            for (float y = 27; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().color = spawnColor;
            }
        }
    }

    void ChangeBaseColor()
    {
        for (float x = 41; x > 36; x--)
        {
            for (float y = 1; y < 6; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().color = _baseColor;
            }
        }
        for (float x = 1; x < 6; x++)
        {
            for (float y = 27; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().color = _baseColor;
            }
        }
    }

    void OnSpawnable()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Gazelle()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_gazelle").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Hyena()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_hyena").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Croco()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_croco").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Cheetah()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_cheetah").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Hippo()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_hippo").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Rhino()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_rhino").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Snake()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_snake").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Lion()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_lion").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Eagle()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_eagle").gameObject.SetActive(true);
            }
        }
    }
    void OnSpawnable_Giraffe()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_giraffe").gameObject.SetActive(true);
            }
        }
    }
    void OffSpawnable()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_gazelle").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_hyena").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_croco").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_cheetah").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_hippo").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_rhino").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_snake").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_lion").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_eagle").gameObject.SetActive(false);
                GameObject.Find($"Tile {x} {y}").transform.Find("spawnable_giraffe").gameObject.SetActive(false);
            }
        }
    }
}
