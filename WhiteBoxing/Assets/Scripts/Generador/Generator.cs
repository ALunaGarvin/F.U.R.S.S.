using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public Texture2D mapa;
    public ColorManagement[] colorObjects;
    float lastPixelX = 0, lastPixelY = 0, calculoXanterior = 0, calculoYanterior = 0;
	void Awake () {
		for(int x = 0; x< mapa.width; x++)
        {
            for(int y = 0; y < mapa.height; y++)
            {
                GenerarMapa(x, y);
            }
        }
	}

    void GenerarMapa(int x, int y)
    {
        Color pixel = mapa.GetPixel(x, y);
        
        if(pixel.a == 0)
        {
            return;
        }
        else
        {
            foreach(ColorManagement colorObject in colorObjects)
            {
                if (colorObject.color.Equals(pixel))
                {
                    Instantiate(colorObject.prefab, new Vector2(x + lastPixelX, y + lastPixelY), Quaternion.identity, transform);
                }
            }
        }
    }

}
