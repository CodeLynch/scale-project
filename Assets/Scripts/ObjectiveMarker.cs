using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveMarker : MonoBehaviour
{
    public GameObject[] objectives;
    public GameObject markerPrefab;

    private SpriteRenderer spriteRenderer;
    private float spriteWidth;
    private float spriteHeight;

    private Camera camera;

    private Dictionary<GameObject, GameObject> markerIndicators = new Dictionary<GameObject, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        spriteRenderer = markerPrefab.GetComponent<SpriteRenderer>();

        var bounds = spriteRenderer.bounds;
        spriteHeight = bounds.size.y / 2f;
        spriteWidth = bounds.size.x / 2f;

        foreach (var target in objectives)
        {
            var indicator = Instantiate(markerPrefab);
            indicator.SetActive(false);
            markerIndicators.Add(target, indicator);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<GameObject, GameObject> entry in markerIndicators)
        {
            var target = entry.Key;
            var indicator = entry.Value;

            UpdateTarget(target, indicator);
        }
    }

    private void UpdateTarget (GameObject target, GameObject indicator)
    {
        var screenPos = camera.WorldToViewportPoint(target.transform.position);
        bool isOffScreen = screenPos.x <= 0 || screenPos.x >= 1 || screenPos.y <= 0 || screenPos.y >= 1;

        if (isOffScreen)
        {
            indicator.SetActive(true);
            var spriteSize = camera.WorldToViewportPoint (new Vector3(spriteWidth, spriteHeight, 0)) - camera.WorldToViewportPoint(Vector3.zero);

            screenPos.x = Mathf.Clamp(screenPos.x, spriteSize.x, 1 - spriteSize.x);
            screenPos.y = Mathf.Clamp(screenPos.y, spriteSize.y, 1 - spriteSize.y);

            var worldPos = camera.ViewportToWorldPoint(screenPos);
            worldPos.z = 0;
            indicator.transform.position = worldPos;

            Vector3 direction = target.transform.position - indicator.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            indicator.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else indicator.SetActive(false);
    }
}
