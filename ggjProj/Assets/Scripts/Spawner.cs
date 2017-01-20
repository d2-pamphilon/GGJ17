using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;

    public bool waveComplete;
    public int wave;
    public int dificulty;//1=all green - 5=all orange - 10=all red 
    public int numOfEnemies;

    // Use this for initialization
    void Start()
    {
        wave = 0;
        dificulty = 1;
        waveComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("space"))
        {
            waveComplete = true;
        }

        if (waveComplete)
        {
            waveComplete = false;
            wave++;
            setNumOfEnimies();

        }



    }

    private void setNumOfEnimies()
    {
        for (int i = 1; i < 11; i++)
        {
            if (wave == i * 3)
            {
                dificulty++;
            }
        }

        numOfEnemies = wave + (2 * wave);
    }

    private void spawnEnimie()
    {
        //dificulty check
        //spawn at location

    }


    public void enemieDead()
    {
        numOfEnemies--;
        if (numOfEnemies >= 0)
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
