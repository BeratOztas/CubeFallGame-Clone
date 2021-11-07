using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -3f, maxX =3f ;
    public float minY = -5.30f;
    private bool out_of_Bounds;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX), transform.position.y, transform.position.z);
        checkBounds();
    }
    void checkBounds()
    {
        Vector2 temp = transform.position;

        if(temp.y <= minY)
        {
            
            if (!out_of_Bounds)
            {
                out_of_Bounds = true;
                
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }

        }

    }//chechBound 
     void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            

            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
