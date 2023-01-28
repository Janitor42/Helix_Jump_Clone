using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] PlatfirmPrefab;
    public int MinPlatform;
    public int MaxPlatform;
    public float DistanceBetweenPlatforms;

    public void Awake()
    {
        int platformsCount= Random.Range(MinPlatform, MaxPlatform+1);
        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex=Random.Range(0, PlatfirmPrefab.Length);
            Vector3 position = new Vector3(0,DistanceBetweenPlatforms*i,0); 
            Quaternion rotation=Quaternion.Euler(0,Random.Range(0,360f),0);
            //Instantiate(PlatfirmPrefab[prefabIndex], position,rotation,transform);

        }
    }
}
