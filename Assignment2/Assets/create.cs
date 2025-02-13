using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 100;
    float time = 0f;
    Vector3[] initPos;

    // Start is called before the first frame update
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];

        for (int i = 0; i < numSphere; i++)
        {
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);

            float t = Mathf.Lerp(0, 2 * Mathf.PI, i / (float)numSphere);
            float x = 3f * Mathf.Pow(Mathf.Sin(t), 3);
            float y = -2 * Mathf.Pow(Mathf.Cos(t), 3) - 2 * Mathf.Pow(Mathf.Cos(t), 2) + 4 * Mathf.Cos(t);
            float z = 0;

            initPos[i] = new Vector3(x, y, z);
            spheres[i].transform.position = initPos[i];

            // Set initial color
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            sphereRenderer.material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // Calculate scale factor using sine wave
        float scaleFactor = 1f + 0.3f * Mathf.Sin(time * 2f); // oscillates between 0.7 and 1.3

        foreach (GameObject sphere in spheres)
        {
            // Apply uniform scaling
            sphere.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            // Color pulse between red and pink
            Color color = Color.Lerp(Color.red, new Color(1f, 0.75f, 0.8f), (Mathf.Sin(time * 2f) + 1f) / 2f);
            sphere.GetComponent<Renderer>().material.color = color;
        }
    }
}
