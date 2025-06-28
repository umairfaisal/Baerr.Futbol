using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


public class RandomSpawn : MonoBehaviour
{
    public GameObject PowerStar;
    public float spawnRate = 0.1f;
    private float timer = 0;
    private Vector2 topLeft = new Vector2(-32, 11);
    private Vector2 topRight = new Vector2(32, 11);
    private Vector2 bottomLeft = new Vector2(-51, -23);
    private Vector2 bottomRight = new Vector2(51, -23);

    private void Update()
    {

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            SpawnStar();
            timer = 0;
        }

        void SpawnStar()
        {
            float y = Random.Range(bottomLeft.y, topLeft.y);

            float xMin = Mathf.Lerp(bottomLeft.x, topLeft.x, (y - bottomLeft.y) / (topLeft.y - bottomLeft.y));
            float xMax = Mathf.Lerp(bottomRight.x, topRight.x, (y - bottomRight.y) / (topRight.y - bottomRight.y));

            float x = Random.Range(xMin, xMax);

            Instantiate(PowerStar, new Vector3(x, y, -1), Quaternion.identity);
        }
    }
}
