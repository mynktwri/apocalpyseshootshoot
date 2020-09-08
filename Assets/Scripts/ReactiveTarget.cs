using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour
{

    public void ReactToHit(int damage)
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.Hurt(damage);


        }
    }

    private void FixedUpdate()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();


        if (!behavior.isAlive())
        {
            StartCoroutine(Die());
        }
    }
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}

