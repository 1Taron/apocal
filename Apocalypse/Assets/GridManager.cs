using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridManager : MonoBehaviour
{
    [SerializeField] private float _width, _height;

    [SerializeField] private Tile _tilePrefab;

    [SerializeField] private Tile _spawntilePrefab;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;

    GameObject ForDestory;


    void Start()
    {
        GenerateGrid();
        Tile.tileD();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        for(float x = 0; x < _width; x++)   //0~41
        {
            for(float y = 0; y < _height; y++)  //0~31
            {
                if (x > 0)  //1~41
                {
                    if(y > 0)   //1~31
                    {
                        if(y % 2 == 0)  //2째 줄마다
                        {
                            float ypos = y - 0.18f * y;
                            float xpos = (x - 0.05f * x) + 0.475f;

                            var spawnedTile = Instantiate(_tilePrefab, new Vector3(xpos, ypos), Quaternion.identity);
                            spawnedTile.name = $"Tile {x} {y}";

                            var _colorValue = 1;
                            switch (y)
                            {
                                case 2:
                                    if (0 < x)
                                    {
                                        if (x < 6)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 4:
                                    if (0 < x)
                                    {
                                        if (x < 7)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 6:
                                    if (0 < x)
                                    {
                                        if (x < 10)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 8:
                                    if (2 < x)
                                    {
                                        if (x < 12)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 10:
                                    if (3 < x)
                                    {
                                        if (x < 17)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 12:
                                    if (6 < x)
                                    {
                                        if (x < 21)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 14:
                                    if (9 < x)
                                    {
                                        if (x < 24)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 16:
                                    if (12 < x)
                                    {
                                        if (x < 27)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 18:
                                    if (16 < x)
                                    {
                                        if (x < 30)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 20:
                                    if (20 < x)
                                    {
                                        if (x < 33)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 22:
                                    if (23 < x)
                                    {
                                        if (x < 35)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 24:
                                    if (26 < x)
                                    {
                                        if (x < 37)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 26:
                                    if (28 < x)
                                    {
                                        if (x < 39)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 28:
                                    if (30 < x)
                                    {
                                        if (x < 42)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 30:
                                    if (33 < x)
                                    {
                                        if (x < 42)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                            }
                            spawnedTile.Init(_colorValue);

                            _tiles[new Vector2(x, y)] = spawnedTile;
                        }
                        else
                        {
                            float ypos = y - 0.18f * y;
                            float xpos = x - 0.05f * x;

                            var spawnedTile = Instantiate(_tilePrefab, new Vector3(xpos, ypos), Quaternion.identity);
                            spawnedTile.name = $"Tile {x} {y}";

                            var _colorValue = 1;
                            switch (y)
                            {
                                case 1:
                                    if (0 < x)
                                    {
                                        if (x < 6)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 3:
                                    if (0 < x)
                                    {
                                        if (x < 7)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 5:
                                    if (0 < x)
                                    {
                                        if (x < 9)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 7:
                                    if (1 < x)
                                    {
                                        if (x < 12)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 9:
                                    if (3 < x)
                                    {
                                        if (x < 15)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 11:
                                    if (5 < x)
                                    {
                                        if (x < 19)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 13:
                                    if (8 < x)
                                    {
                                        if (x < 23)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 15:
                                    if (10 < x)
                                    {
                                        if (x < 26)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 17:
                                    if (15 < x)
                                    {
                                        if (x < 29)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 19:
                                    if (18 < x)
                                    {
                                        if (x < 32)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 21:
                                    if (22 < x)
                                    {
                                        if (x < 35)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 23:
                                    if (25 < x)
                                    {
                                        if (x < 36)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 25:
                                    if (27 < x)
                                    {
                                        if (x < 38)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 27:
                                    if (30 < x)
                                    {
                                        if (x < 41)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 29:
                                    if (32 < x)
                                    {
                                        if (x < 42)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;
                                case 31:
                                    if (34 < x)
                                    {
                                        if (x < 42)
                                        {
                                            _colorValue = 4;
                                            spawnedTile.Init(_colorValue);
                                            break;
                                        }
                                        else
                                            break;
                                    }
                                    else
                                        break;

                            }
                            spawnedTile.Init(_colorValue);
                            _tiles[new Vector2(x, y)] = spawnedTile;
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        //GenerateGrid02();

                _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f - 1.0f, -10);

    }
    
    void GenerateGrid02()
    {
        for (float x = _width - 1; x > 35; x--)
        {
            for (float y = 1; y < 6; y++)
            {

                ForDestory = GameObject.Find($"Tile {x} {y}");
                Destroy(ForDestory);

                float xpos = GameObject.Find($"Tile {x} {y}").transform.position.x;
                float ypos = GameObject.Find($"Tile {x} {y}").transform.position.y;

                var spawnedTile = Instantiate(_spawntilePrefab, new Vector3(xpos, ypos), Quaternion.identity);
                spawnedTile.name = $"SpawnTile {x} {y}";
                var _colorValue = 1;
                spawnedTile.Init(_colorValue);
            }
        }
    }


    public Tile GetTileAtPosition(Vector2 pos)
    {
        if(_tiles.TryGetValue(pos,out var tile))
        {
            return tile;
        }
        return null;
    }
}
