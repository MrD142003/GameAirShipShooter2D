using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private BoxCollider2D _box;

    private void Awake()
    {
        _box = this.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpwanerEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpwanerEnemy()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        float minX = -_box.bounds.size.x / 2f;
        float maxX = _box.bounds.size.x / 2f;

        Vector3 temp = this.transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(_enemy, temp, Quaternion.identity);

        StartCoroutine(SpwanerEnemy());
    }
}
