using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    public float speed = 10.0f;
    private float temp_value;
    Camera C;
    Vector2 MousePosition;
    //float camerax = Camera.main.transform.position.x + 10.0f;
    //float cameray = Camera.main.transform.position.y;
    public GameObject AssX;
    public GameObject Ass_X;
    public GameObject AssY;
    public GameObject Ass_Y;
    Transform AssXT;
    Transform Ass_XT;
    Transform AssYT;
    Transform Ass_YT;

    void Start()
    {
        C = GameObject.Find("Main Camera").GetComponent<Camera>();
        AssXT = AssX.transform;
        Ass_XT = Ass_X.transform;
        AssYT = AssY.transform;
        Ass_YT = Ass_Y.transform;

    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * speed;

        if (C.orthographicSize <= 5.0f && scroll > 0)
        {
            temp_value = C.orthographicSize;
            C.orthographicSize = temp_value;
        }
        else if (C.orthographicSize >= 15.0f && scroll < 0)
        {
            temp_value = C.orthographicSize;
            C.orthographicSize = temp_value;
        }
        else
            C.orthographicSize -= scroll * 0.5f;

        MousePosition = Input.mousePosition;

        LimitCameraMove();
        ArrowMoving();
    }
    void ArrowMoving()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-0.025f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(0.025f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0f, 0.025f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0f, -0.025f, 0f);
        }
    }

    void LimitCameraMove()
    {
        if (C.orthographicSize <= 14.0f)
        {
            if (MousePosition.x > 2000)
            {

                transform.position = Vector3.Lerp(transform.position, AssXT.position, Time.deltaTime * 0.035f);
                float clampx = Mathf.Clamp(Camera.main.transform.position.x, 9, 39);
                float clampy = Mathf.Clamp(Camera.main.transform.position.y, 5, 20);
                transform.position = new Vector3(clampx, clampy, -10f);
            }
            else if (MousePosition.x < 0)
            {

                transform.position = Vector3.Lerp(transform.position, Ass_XT.position, Time.deltaTime * 0.035f);
                float clampx = Mathf.Clamp(Camera.main.transform.position.x, 9, 39);
                float clampy = Mathf.Clamp(Camera.main.transform.position.y, 5, 20);
                transform.position = new Vector3(clampx, clampy, -10f);
            }
            else if (MousePosition.y > 1100)
            {

                transform.position = Vector3.Lerp(transform.position, AssYT.position, Time.deltaTime * 0.035f);
                float clampx = Mathf.Clamp(Camera.main.transform.position.x, 9, 39);
                float clampy = Mathf.Clamp(Camera.main.transform.position.y, 5, 20);
                transform.position = new Vector3(clampx, clampy, -10f);
            }
            else if (MousePosition.y < 0)
            {

                transform.position = Vector3.Lerp(transform.position, Ass_YT.position, Time.deltaTime * 0.035f);
                float clampx = Mathf.Clamp(Camera.main.transform.position.x, 9, 39);
                float clampy = Mathf.Clamp(Camera.main.transform.position.y, 5, 20);
                transform.position = new Vector3(clampx, clampy, -10f);
            }
        }
    }

}
