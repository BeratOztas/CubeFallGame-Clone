using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarSpawner : MonoBehaviour
{
   
    public GameObject starPrefab;
    public float minX = -2.5f, maxX = 2.5f;
    public Text starText;

     void Start()
    {
        StartCoroutine(StarSpawnerCoroutine());
    }



    void Update()
    {
        showStarCount();
    }
    void showStarCount()
    {
        starText.text = "" + StarScript.starCount;
    }
    IEnumerator StarSpawnerCoroutine()
    {
        while (true)
        {
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newStar = null;

            newStar=Instantiate(starPrefab, temp, Quaternion.identity);
            yield return new WaitForSeconds(5f);

            
        }

    }
    


}
