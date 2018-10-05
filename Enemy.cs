using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string monsterName;
    public int hp;
     int directionX;
     int directionY;
    public float speed;
    public TextMesh hpText;
    public BattleSystem bs;
    public Transform Sprite;
     
    
    

	// Use this for initialization
	void Start ()
    {
      
        //Random start directionX
        directionX = Random.Range(-20, 20); //0,1
        if(directionX == 0)
        {
            directionX = -1;
        }
        //Random start directionY
        directionY = Random.Range(-20, 20); //0,1
        if (directionY == 0)
        {
            directionY = -1;
        }

        UpdateHP();
    }

    // Update is called once per frame
    void Update ()
    {

        MoveMent();
 
    }


    void MoveMent()
    {
        Transform t = this.transform;
        

        //เก็บ
        Vector3 pos = t.localPosition;

        //เปลี่ยน
        if (pos.x > 60)
        {
           
            directionX =  - Random.Range(1,5) ;
        }
        else if(pos.x < -60)
        {
          
            
            directionX = Random.Range(1, 5);
        }
        pos.x = pos.x + speed * Time.deltaTime * directionX;

//----------------------------------------------------------------------------------

        if (pos.y >  30f)
        {
            directionY = - Random.Range(1, 5);
        }
        else if (pos.y < -30f)
        {
            directionY = Random.Range(1, 5);
        }
        pos.y = pos.y + speed * Time.deltaTime * directionY;

        //ใส่คืน
        t.localPosition = pos;


    }


    public void UpdateHP()
    {
        hpText.text = hp + "";       

        if(hp <= 0)
        {

            bs.num = bs.num - 1;
            

            bs.scoreManager.AddScore(100);
            bs.scoreManager.CreateFloatingScore(100, this.transform);

            Destroy(this.gameObject);
        }

    }
    

    public void Damage(int dmg)
    {
        hp = hp - dmg;
        UpdateHP();
    }
}
