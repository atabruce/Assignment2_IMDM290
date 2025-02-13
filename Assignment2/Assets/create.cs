using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{
    GameObject[] spheres;
    static int numSphere = 100;  // Number of spheres to create
    float time = 0f;
    Vector3[] initPos;

    // Start is called before the first frame update
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];

        for (int i = 0; i < numSphere; i++)
        {
            float t = (i / (float)numSphere) * 2 * Mathf.PI; // t values from 0 to 2π
            float x = Mathf.Sqrt(2) * Mathf.Pow(Mathf.Sin(t), 3);
            float y = -Mathf.Pow(Mathf.Cos(t), 3) - Mathf.Pow(Mathf.Cos(t), 2) + 2 * Mathf.Cos(t);
            float z = 0f; // Keep it 2D in the XY plane

            // Create the sphere
            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            initPos[i] = new Vector3(x * 5f, y * 5f, z); // Scale the heart size
            spheres[i].transform.position = initPos[i];

            // Assign colors based on position
            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();
            float hue = (float)i / numSphere; // Different colors along the heart shape
            Color color = Color.HSVToRGB(hue, 1f, 1f);
            sphereRenderer.material.color = color;
        }
    }
}
