using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsBG : MonoBehaviour
{
    [SerializeField] private float parallaxFx = 2f;
    private MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x = transform.position.x / transform.localScale.x/parallaxFx;
        offset.y = transform.position.y / transform.localScale.y/parallaxFx;

        mat.mainTextureOffset = offset;


    }
}
