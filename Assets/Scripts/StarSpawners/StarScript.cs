using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_y = 7.5f;
    public static int starCount = 0;
   
    void Update()
    {
        Move();
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SoundManager.instance.starCollectSound();
            starCount++;
            
            Destroy(gameObject);
        }
    }
    
    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_y)
        {
            gameObject.SetActive(false);
        }

    }
}
