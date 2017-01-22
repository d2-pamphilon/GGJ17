using UnityEngine;
using System.Collections;

public class EnimieBehavour : MonoBehaviour
{
    //when bullet hits
    //minus from other script
    //delete myself
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;

    public Rigidbody2D RB;
    public float speed;
    public float rotSpeed;
    int enemieType;
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
        if (this.gameObject.tag == "easy")
        { enemieType = 1; speed = 2; }
        if (this.gameObject.tag == "medium")
        { enemieType = 2; speed = 3; }
        if (this.gameObject.tag == "hard")
        { enemieType = 3; speed = 4; }



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

        if (coll.gameObject.tag == "Bullet")
        {
            m_Spawner.enemieDead();
            m_score.setScore(1);
            death();
        }


        if (coll.gameObject.tag == "World")
        {
            m_Spawner.enemieDead();
            m_score.minusLives(1);
            death();
        }

        if (coll.gameObject.tag == "Player")
        {
            m_Spawner.enemieDead();
            m_score.minusLives(1);
            death();
        }

    }
    private void death()
    {
        switch (enemieType)
        {
            case 1:
                Instantiate(P1, this.transform.position, this.transform.rotation);
                break;
            case 2:
                Instantiate(P2, this.transform.position, this.transform.rotation);
                break;
            case 3:
                Instantiate(P3, this.transform.position, this.transform.rotation);
                break;
            default:
                break;
        }
        Destroy(this.gameObject);
    }

}
