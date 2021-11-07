using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject breakablePlatformPrefab;
    public GameObject spikePlatformPrefab;
    
    public GameObject[] movingPlatforms;
    public float platform_spawn_timer = 2f;
    private float current_Platform_spawn_timer;
    public float minX = -2.5f, maxX = 2.5f;
    private int platform_spawn_count;
    // Start is called before the first frame update
    // 2 moving 3 spike 4 de breakble olacak ve bunlarýn gelmesi rastgele olacak.
    // count =0 ,current spawntimer =0;
    void Start()
    {
        current_Platform_spawn_timer = platform_spawn_timer;
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlatform();
    }
    void spawnPlatform()
    {
        current_Platform_spawn_timer += Time.deltaTime;


        if(current_Platform_spawn_timer >= platform_spawn_timer)
        {
            platform_spawn_count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;

            if(platform_spawn_count < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if(platform_spawn_count == 2)
            {
                if(Random.Range(0,2) == 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0,movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platform_spawn_count == 3)
            {
                if (Random.Range(0, 2) == 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platform_spawn_count == 4)
            {
                if (Random.Range(0, 2) == 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(breakablePlatformPrefab, temp, Quaternion.identity);
                }
               
                platform_spawn_count = 0;
            }
            newPlatform.transform.parent = transform;//The Platform that we have just inst it'll be child of PlatformSpawnerObj.
            current_Platform_spawn_timer = 0f;

        }//First If

    }//spawnPlatform
    






}//Class
