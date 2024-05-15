using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameera : MonoBehaviour
{
    [SerializeField] private GameObject vehiclePrefab;
    private Vector3 offset = new Vector3(0, 4, -8.3f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = vehiclePrefab.transform.position + offset;
    }
}
