using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploerController : MonoBehaviour
{
    public Vector2 pos;
    public float scale;
    public bool autoLockCursor;
    public float sensivity = 200.0f;
    public float currentFloat = 2.0f;
    public Material mat;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void UpdateShader()
    {
        float aspect = (float)Screen.width / (float)Screen.height;

        float scaleX = scale;
        float scaleY = scale;
        
        if (aspect > 1f)
            scaleY /= aspect;
        else
            scaleX *= aspect;

        mat.SetVector("_Area", new Vector4(pos.x, pos.y, scaleX, scaleY));
        
    }

    private void FixedUpdate()
    {
        HandleInputs();
        UpdateShader();

    }

    // Update is called once per frame
   private void HandleInputs()
    {

        //if (Input.GetKey(KeyCode.E))
        //    scale *= 0.99f;  //zoom in by 1%
        //if (Input.GetKey(KeyCode.Q))
        //    scale *= 1.01f; //zoom out by 1%

        if (Input.GetMouseButton(0))
            scale *= 0.99f;  //zoom in by 1%
        if (Input.GetMouseButton(1))
            scale *= 1.01f; //zoom out by 1%

        if (Input.GetKey(KeyCode.W))
            pos.y += 0.01f * scale;
        if (Input.GetKey(KeyCode.S))
            pos.y -= 0.01f * scale;
        if (Input.GetKey(KeyCode.D))
            pos.x += 0.01f * scale;
        if (Input.GetKey(KeyCode.A))
            pos.x -= 0.01f * scale;

        if (Input.GetKey(KeyCode.Space))
        {
            scale = 4;
            pos.y = 0;
            pos.x = 0;
        }
        if (Input.GetKey(KeyCode.R))
        {
            currentFloat = 2.0f;
            mat.SetFloat("_Float", currentFloat);
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentFloat += 0.1f;
            mat.SetFloat("_Float", currentFloat);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            currentFloat -= 0.1f;
            mat.SetFloat("_Float", currentFloat);
        }


    }
}
