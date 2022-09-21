using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalStar;

    StarPool starPool;
    private void Start()
    {
        //InstantiateStar();
        starPool = GetComponent<StarPool>();
        GameManager.instance.gameStart += onGameStart;
    }

    void onGameStart()
    {
        spawnNumberofStar(totalStar);
    }

    void spawnNumberofStar(int totalStar)
    {
        for (int i = 0; i < totalStar; i++)
        {
            starPool.GetStar(getRandomPosition()).SetActive(true);
        }
    }

    bool inRange(float value, float minVal, float maxVal)
    {
        if (value > minVal && value < maxVal)
        {
            return true;
        }
        return false;

    }
    // don't spawn in this range
    float sphereMinX= -0.44f, sphereMaxX= 0.44f;
    float sphereMinZ=-0.51f, sphereMaxZ= 0.51f;
    public Vector3 getRandomPosition()
    {
        float x = Random.Range(-1.05f, 1.05f); //x
        float z = Random.Range(-1.86f, 1.86f);
        while(inRange(x, sphereMinX, sphereMaxX))
        {
            x = Random.Range(-1.05f, 1.05f);
            Debug.Log("fall in sphere x");
        };
        while (inRange(z, sphereMinZ, sphereMaxZ))
        {
            z = Random.Range(-1.86f, 1.86f);
            Debug.Log("fall in sphere z");

        };
        return new Vector3(x, 0, z);
    }

    private void OnDestroy()
    {
        GameManager.instance.gameStart -= onGameStart;

    }
}
