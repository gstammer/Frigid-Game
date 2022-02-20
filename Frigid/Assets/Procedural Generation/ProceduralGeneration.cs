using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] int minHeight, maxHeight;
    [SerializeField] int repeatNum;//5
    [SerializeField] int spikeSpawnHeight;
    [SerializeField] GameObject under, surface, spike;
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
        if (height < spikeSpawnHeight)
        {
            spawnObj(surface, x, height);
            spawnObj(spike, x, height + 1);
        }
        else
        {
            spawnObj(surface, x, height);
        } 
    }

    void spawnObj(GameObject obj, int width, int height)//What ever we spawn will be a child of our procedural generation gameObj
    {
        obj = Instantiate(obj, new Vector2(width, height), Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
