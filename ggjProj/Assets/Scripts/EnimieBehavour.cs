using UnityEngine;
using System.Collections;

public class EnimieBehavour : MonoBehaviour
{
    //when bullet hits
    //minus from other script
    //delete myself

    public Rigidbody2D RB;
    public float speed;
    public float rotSpeed;
    public GameObject bullet;

    private Vector3 rotation;
    // private GameObject tempGO;

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
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), new Vector2(0f, 0f), speed * Time.deltaTime);


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject tempGO = GameObject.FindGameObjectWithTag("SpawnControler");
        Spawner m_Spawner = tempGO.GetComponent<Spawner>();
        Score m_score = tempGO.GetComponent<Score>();

        if (coll.gameObject.tag == "bullet")
        {

            m_Spawner.enemieDead();
            
            Destroy(this);
        }


        if (coll.gameObject.tag == "World")
        {
            m_Spawner.enemieDead();
            //-life
            Destroy(this);
        }

        if (coll.gameObject.tag == "Player")
        {
            m_Spawner.enemieDead();
            //-life
            Destroy(this);
        }

    }

}
