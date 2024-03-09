using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _speed;
    private Rigidbody2D _rigi;

    private void Awake()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigi.velocity = new Vector2(0, -_speed);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            Destroy(target.gameObject);
            GamePlayController.instance.AirPlaneDiedShowPanel();
        }

        if (target.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
