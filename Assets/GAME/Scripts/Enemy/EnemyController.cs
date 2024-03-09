using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _enemySpeed;
    [SerializeField] private GameObject _bullet;
    private Rigidbody2D _rigi;

    private void Awake()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(EnemyShoot());    
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        _rigi.velocity = new Vector2(0, -_enemySpeed);
    }

    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        Vector3 temp = this.transform.position;
        temp.y -= 0.5f;
        Instantiate(_bullet, temp, Quaternion.identity);

        StartCoroutine(EnemyShoot()) ;
    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {         
            Destroy(target.gameObject);
            GamePlayController.instance.AirPlaneDiedShowPanel();
        }        
        

        if (target.tag == "Border")
            Destroy(gameObject);
    }
}
