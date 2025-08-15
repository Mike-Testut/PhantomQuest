using UnityEngine;
using Unity.Cinemachine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D forrest1Boundary; 
    [SerializeField] private PolygonCollider2D cemetary1Boundary;
    
    private CinemachineConfiner2D confiner;
    private Transform player;

    private PolygonCollider2D currentArea;
    
    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (forrest1Boundary == null)
        {
            GameObject forrest1 = GameObject.Find("Forrest1");
            if (forrest1 != null)
                forrest1Boundary = forrest1.GetComponent<PolygonCollider2D>();
        }
        
        if (cemetary1Boundary == null)
        {
            GameObject cemetary1 = GameObject.Find("Cemetary1");
            if (cemetary1 != null)
                cemetary1Boundary = cemetary1.GetComponent<PolygonCollider2D>();
        }

        currentArea = cemetary1Boundary;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentArea == cemetary1Boundary)
            {
                confiner.BoundingShape2D = forrest1Boundary;
                currentArea = forrest1Boundary;
            }
            else if(currentArea ==  forrest1Boundary)
            {
                confiner.BoundingShape2D = cemetary1Boundary;
                currentArea = cemetary1Boundary;
            }
        }
    }
    
}
