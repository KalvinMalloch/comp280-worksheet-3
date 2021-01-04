using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    Mesh water;
    Vector3[] verticies;
    public float waveRange;
    public float waveSpeed;
    float[] targetHeight;

    void Start()
    {
        water = GetComponent<MeshFilter>().mesh;
        verticies = water.vertices;
        targetHeight = new float[verticies.Length];

        for (int i = 0; i < targetHeight.Length; i++)
        {
            targetHeight[i] = Random.Range(-waveRange, waveRange);
            verticies[i].y = targetHeight[i];
            targetHeight[i] = Random.Range(-waveRange, waveRange);
        }

        water.vertices = verticies;
        water.RecalculateNormals();
    }

    void Update()
    {
        for (int i = 0; i < verticies.Length; i++)
        {

            if (targetHeight[i] > verticies[i].y)
            {
                verticies[i].y += waveSpeed;

                if (targetHeight[i] < verticies[i].y)
                {
                    targetHeight[i] = Random.Range(-waveRange, waveRange);
                }
            }

            else if (targetHeight[i] < verticies[i].y)
            {
                verticies[i].y -= waveSpeed;

                if (targetHeight[i] > verticies[i].y)
                {
                    targetHeight[i] = Random.Range(-waveRange, waveRange);
                }
            }
            water.vertices = verticies;
        }
        water.RecalculateNormals();
    }
}
