using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    float obstacleSpeed;
    private Player3 playerScript;
    float leftBoundX=8f;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.gameOver==false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * obstacleSpeed);
        }
        
        if(transform.position.x < -leftBoundX && gameObject.CompareTag("obs"))
        {
            Destroy(gameObject);
        }
    }
}
