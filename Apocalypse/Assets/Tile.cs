using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    [SerializeField] private Sprite _basesprite, _offsetsprite, _spawnsprite, _riversprite;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    public static Action tileA;
    public static Action tileB;
    public static Action tileA2;
    public static Action tileGrass;

    private void Awake()
    {
        tileA = () => { ChangeSpawnColor(); };
        tileB = () => { ChangeBaseColor(); };
        tileA2 = () => { ChangeSpawnColorPlayer2(); };
        tileGrass = () => { GrassTileChange(); };
    }

    public void Init(int _colorValue)
    {
        switch (_colorValue)
        {
            case 1:
                _renderer.sprite = _basesprite;
                break;
            case 2:
                _renderer.sprite = _offsetsprite;
                break;
            case 3:
                _renderer.sprite = _spawnsprite;
                break;
            case 4:
                _renderer.sprite = _riversprite;
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
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().sprite = _spawnsprite;
            }
        }
    }

    void ChangeSpawnColorPlayer2()
    {
        for (float x = 1; x < 6; x++)
        {
            for (float y = 27; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().sprite = _spawnsprite;
            }
        }
    }

    void ChangeBaseColor()
    {
        for (float x = 41; x > 36; x--)
        {
            for (float y = 1; y < 6; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().sprite = _spawnsprite;
            }
        }
        for (float x = 1; x < 6; x++)
        {
            for (float y = 27; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().sprite = _spawnsprite;
            }
        }
    }

    void GrassTileChange()
    {
        for (float x = 1; x < 42; x++)
        {
            for (float y = 1; y < 32; y++)
            {
                if (GameObject.Find($"Tile {x} {y}").transform.Find("Grass").gameObject.activeSelf == false && 
                    GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().sprite.name == "hexGrass04_0")
                {
                    GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().sprite = _offsetsprite;
                }
            }
        }
    }
}
