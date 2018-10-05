﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneManager : MonoBehaviour
{

    public TextMesh HighscoreText;

    // Use this for initialization
    void Start()
    {
        HighscoreText.text = "High score : "+ PlayerPrefs.GetInt("Highscore");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "StartButton")
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene("xcz");

                }

            }
        }
    }
}
