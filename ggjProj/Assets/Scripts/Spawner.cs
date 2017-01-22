using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spawner : MonoBehaviour
{

    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;


    public GameObject easy;
    public GameObject medium;
    public GameObject hard;

    public bool waveComplete;
    public int wave;
    public int dificulty;//0=all green - 50=all orange - 100=all red 
    public int numOfEnemies;
    public Vector2 spawnValues;

    private Vector2 spawnPos;
    // Use this for initialization
    void Start()
    {
        wave = 0;
        dificulty = 0;
        waveComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            waveComplete = true;
        }

        if (waveComplete)
        {
            waveComplete = false;
            wave++;
            dificulty+=2;
            setNumOfEnimies();
            StartCoroutine(spawnEnemie());
        }
    }
    
    private void setNumOfEnimies()
    {
        numOfEnemies = 3 * wave;
    }

    IEnumerator spawnEnemie()
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            //spawn
            location();
            if (dificulty <= 50)
            {
                if (!randomBool(dificulty))
                {
                    Instantiate(medium, spawnPos, up.transform.rotation);
                    //spawn medium
                }
                else
                {
                    Instantiate(easy, spawnPos, up.transform.rotation);
                    //spawn easy
                }
            }
            else
            {
                if (!randomBool(dificulty))
                {
                    Instantiate(hard, spawnPos, up.transform.rotation);
                    //spawn hard
                }
                else
                {
                    Instantiate(medium, spawnPos, up.transform.rotation);
                    //spawn medium
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
    }


    private void location()
    {
        if (randomBool(50))
        {
            if (randomBool(50))
            {
                spawnPos = new Vector2(left.transform.position.x, (Random.Range(-spawnValues.y, spawnValues.y)));
            }
            else
            {
                spawnPos = new Vector2(right.transform.position.x, (Random.Range(-spawnValues.y, spawnValues.y)));
            }

        }
        else
        {
            if (randomBool(50))
            {
                spawnPos = new Vector2((Random.Range(-spawnValues.x, spawnValues.x)), up.transform.position.y);
            }
            else
            {
                spawnPos = new Vector2((Random.Range(-spawnValues.x, spawnValues.x)), down.transform.position.y);
            }

        }
    }


    private bool randomBool(float chance)
    {

        if (Random.value >= chance / 100)
        {
            return true;
        }
        return false;
    }



    public void enemieDead()
    {
        numOfEnemies--;

        if (numOfEnemies <= 0)
        {
            waveComplete = true;
        }
    }


    //wave num
    //spawn at one of locations, heading towards center of screen
    //after all enemies killed, wave++, 
    //wave = dificulty and enmy num
    //when new enemy type lower enmynum that round



}