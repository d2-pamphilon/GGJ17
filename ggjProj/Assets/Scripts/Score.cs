using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    //score
    //lives 
    public int score;
     public int lives;
	// Use this for initialization
	void Start () {
        score = 0;
        lives = 5; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getLives()
    { return lives; }

    public int getScore()
    { return score; }

    public void setScore(int toAdd)
    { score += toAdd; }

    public void minusScore(int toMinus)
    { score -= toMinus; }

    public void minusLives(int toMinus)
    { lives -= toMinus; }

}
