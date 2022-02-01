using UnityEngine;
using System.Collections;

public class textureChanger : MonoBehaviour
{

    
    public float count = 0;

    void Start()
    {
         Texture2D texture = new Texture2D(100, 100);
         GetComponent<Renderer>().material.mainTexture = texture;


        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                //Create triangle pattern       Color color = ((x & y) != 0 ? Color.white : Color.grey); 
                //Color color = new Color((float)255 / texture.height, (float)255 / texture.width, (float)(x + count) / texture.width, 255);
                    texture.SetPixel(x, y, Color.white);
                
            }
        }
        texture.Apply();

    }

    void Update()
    {
        Texture2D texture = (Texture2D)GetComponent<Renderer>().material.mainTexture;

        //texture.SetPixel(count - 1, (int)Mathf.Abs(Mathf.Sin(count - 1) * texture.height), Color.blue);
       // for (int x = 0; x < 10; x++)
        texture.SetPixel((int)count /*+ x*/, 50 + (int)(Mathf.Sin(count) * 50), Color.black);
      
        texture.Apply();

        
        if (count == texture.width)
            count = 0;
           

        count += 0.05f;
       
    }
}