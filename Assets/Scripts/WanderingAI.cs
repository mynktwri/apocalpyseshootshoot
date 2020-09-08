using UnityEngine;
using System.Collections;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private bool _alive = true;
    private int health = 5;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private void FixedUpdate()
    {
        
    }


    void Update()
    {
        if (keepAlive())
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    public bool isAlive()
    {
        return _alive;
    }

    private bool keepAlive()
    {
        if (health > 0)
        {
            return true;
        }
        else
        {
            _alive = false;
            return false;
        }
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log("Enemy hit, life remaining: " + health);
    }
}

//Values for the speed of movement and how far away to react to obstacles
//Move forward continuously every frame, regardless of turning.
//A ray at the same position and pointing the same direction as the character
//Do raycasting with a circumference around the ray.
//Turn toward a semi-random new direction.