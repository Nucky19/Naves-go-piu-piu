using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 direction;

  
    public void Launch(Vector2 dir)
    {
        direction = dir;
        gameObject.SetActive(true); 
    }

    void Update()
    {
       
        transform.Translate(direction * speed * Time.deltaTime);
        
      
        if (transform.position.y > Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }

   
}