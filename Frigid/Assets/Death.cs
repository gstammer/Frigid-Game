using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        float minPosition = camera.transform.position.x - halfWidth;

        if (transform.position.x < minPosition) {
            SceneManager.LoadScene("Level 1");
        }
    }
}
