using UnityEngine;

public class BackGroundRpt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 startPos;
    private float repeatWidth;
    void Start()
    {
        startPos = transform.position; 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; 
    }

    // Update is called once per frame
    void Update()
    {
        if (startPos.x - repeatWidth >= transform.position.x) 
        {
            transform.position = startPos;
            Debug.Log(transform.position.x);
        }
    }
}
