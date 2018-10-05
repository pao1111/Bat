using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public int myDamage;
    public Transform batPrefab;
    public Transform batParent;
    public ScoreManager scoreManager;
    public Animation curserAnime;

    public int num = 0;

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        //raycast
        if (Input.GetMouseButtonDown(0) && scoreManager.gameover == false)
        {
            SoundManager.instance.PlaySound();

            curserAnime.Play();

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit))
            {             
                if (hit.transform.tag == "Monster")
                {
                    hit.transform.GetComponent<Enemy>().Damage(myDamage);
                }
                else
                {
                   
                    scoreManager.Miss();
                }
            }
            else
            {
                scoreManager.Miss();

            }
        }

        //clone


        if (num < 3) 
        {
           
                CloneBat();
          
        }
           
    }

        void CloneBat()
        {
            Transform clone = Instantiate(batPrefab);
            clone.SetParent(batParent);
            clone.localPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f,2f), 0);
            clone.localEulerAngles = new Vector3(0, 0, 0);
            clone.localScale = new Vector3(1, 1, 1);

            clone.GetComponent<Enemy>().bs = this;

        num = num + 1;

        }
}