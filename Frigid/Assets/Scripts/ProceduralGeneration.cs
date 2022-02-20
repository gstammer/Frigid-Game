using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum;//5
    [SerializeField] GameObject coin, surface, under;
    void Start()
    {
        Generation();
    }

    void Generation()
    {
        int repeatValue = 1;
        for (int x = 0; x < width; x++)//This will help spawn a tile on the x axis
        {
         if(repeatValue == 1)
            {
                height = Random.Range(minHeight, maxHeight);
                GenerateFlatPlatform(x);
                repeatValue = repeatNum;
            }
            else
            {
                GenerateFlatPlatform(x);
                repeatValue--;
            } 
        }
    }

    void GenerateFlatPlatform(int x)
    {
        for (int y = 0; y < height; y++)//This will help spawn a tile on the y axis
        {
            spawnObj(under, x, y);
        }
            spawnObj(surface, x, height);
            GenerateCoin(x,height);
    }

    void GenerateCoin(int x, int height){
        int chance=Random.Range(1,10);
        if (chance % 2==0){
            spawnObj(coin, x, height+1);
        }
    }
    void spawnObj(GameObject obj, int width, int height)//What ever we spawn will be a child of our procedural generation gameObj
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
