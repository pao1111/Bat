using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    [Header("Setup")]
    public TextMesh ScoreText;
    public TextMesh LifeText;
    public int MaxLife;

    public GameObject gameoverObj;
    public Transform Scoreprefab;
    public Transform Scoreparent;

    [Header("Debug")]
     int score;
     int life;
     public bool gameover;
    

	// Use this for initialization
	void Start () {

        gameoverObj.SetActive(false);
        life = MaxLife;
        UpdateText();

	}
	
    public void AddScore(int add)
    {
        score = score + add;
        UpdateText();
     

        int highscore = PlayerPrefs.GetInt("Highscore");

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
    }

    public void CreateFloatingScore(int gain, Transform Bat)
    {
        Transform clone = Instantiate(Scoreprefab);
        clone.SetParent(Bat);
        clone.localPosition = new Vector3(0,0,0);
        clone.localEulerAngles = new Vector3(0, 0, 0);
        clone.localScale = new Vector3(1, 1, 1);


        clone.SetParent(Scoreparent);
        clone.Find("Text").GetComponent<TextMesh>().text = gain.ToString();


    } 


    void  UpdateText()
    {
        ScoreText.text = "Score : " + score;
        LifeText.text = "Life : " + life;
    }

    public void Miss()
    {

        life = life - 1;
        UpdateText();
        if(life <= 0)
        {
            gameoverObj.SetActive(true);
            gameover = true;

            Invoke("Restart",2);

        }

    }

    void Restart()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");

    }
	
}
