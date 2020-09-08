using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class small_bullet : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;
    public float life = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, life);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        ReactiveTarget tgt = other.GetComponent<ReactiveTarget>();
        if (tgt != null) {
            Debug.Log("Enemy Hit");
            tgt.ReactToHit(damage);
        }
        Destroy(this.gameObject);
    }
}
