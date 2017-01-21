using UnityEngine;
using System.Collections;

public class EnimieBehavour : MonoBehaviour
{

    public Rigidbody2D RB;
    public float speed;
    public float rotSpeed;
    private Vector3 rotation;
    // Use this for initialization
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        if (Random.value >= 0.5)
        {
            rotation = new Vector3(0f, 0f, 0.1f);
        }
        else
        {
            rotation = new Vector3(0f, 0f, -0.1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
            transform.Rotate(rotation * rotSpeed * Time.deltaTime);
       
       
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),new Vector2(0f,0f), speed * Time.deltaTime);
    }


    
}
