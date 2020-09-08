using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private GameObject _enemy;
    void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab1) as GameObject;
            _enemy.transform.position = new Vector3(0, 1, 0);
            //float angle = Random.Range(0, 360);
            float angle = 0;
            _enemy.transform.Rotate(0, angle, 0);
        }
    }
}
