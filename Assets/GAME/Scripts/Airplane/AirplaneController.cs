using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] private GameObject _bullet;
    private Rigidbody2D _rigi;
    Vector2 _movement;
    private bool _canShoot = true;

    private void Awake()
    {
        _rigi = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.AirplaneMovement();
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            if (_canShoot)
                StartCoroutine(Shoot());
        }
    }
    void AirplaneMovement()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _rigi.velocity = _movement.normalized * _speed;
    }
    IEnumerator Shoot()
    {
        _canShoot = false;

        Vector3 temp = this.transform.position;
        temp.y += 0.8f;
        Instantiate(_bullet, temp, Quaternion.identity);

        yield return new WaitForSeconds(0.2f);
        _canShoot = true;
    }
}
