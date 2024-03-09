using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField] float _speed;
    private Rigidbody2D _rigi;
    public int score = 0; 

    private void Awake()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigi.velocity = new Vector2(0, _speed);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy")
        {
            score++;
            if (GamePlayController.instance != null)
            {
                GamePlayController.instance.SetScore(score);
            }
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

        if(target.tag == "Border")
        {
            Destroy(gameObject);
        }       
        
        
    }
}
