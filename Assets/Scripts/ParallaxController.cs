using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;
    private int layersCount;
    private Vector3 posY;

    void Start()
    {
        layersCount = layers.Length;
        posY = transform.position;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        //pos.y = posY.y;
        for (int i = 0; i < layersCount; i++)
        {

            layers[i].position = pos* coeff[i];
        }
    }
}
