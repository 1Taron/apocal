using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor, spawnColor, _riverColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight, _spawnable;

    public static Action tileA;
    public static Action tileB;
    public static Action tileA2;

    private void Awake()
    {
        tileA = () => { ChangeSpawnColor(); };
        tileB = () => { ChangeBaseColor(); };
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
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().color = _offsetColor;
            }
        }
        for (float x = 1; x < 6; x++)
        {
            for (float y = 27; y < 32; y++)
            {
                GameObject.Find($"Tile {x} {y}").GetComponent<SpriteRenderer>().color = _offsetColor;
            }
        }
    }


}
