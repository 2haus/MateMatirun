using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResizer : MonoBehaviour
{
    /*
     * 4:3 = 3.74f + pull y axis to -1.26f
     * 3:2 = 4.21f + pull y axis to -0.79f
     * 16:10 = 4.5f + pull y axis to -0.5f
     * 5:3 (15:9) = 4.68f + pull y axis to -0.32f
     * 16:9 = 5f
     * 18:9 = 5.62f + shift y axis to 0.62f
     * 19:9 = 5.92f + shift y axis to 0.92f
     * 20:9 = 6.24f + shift y axis to 1.2f
     * 21:9 = 6.56f + shift y axis to 1.56f
     */

    // screen sizes are constant. if nothing matches, use closest value possible
    const float SCREEN_RATIO_4_3 = 3.74f;
    const float SCREEN_RATIO_3_2 = 4.21f;
    const float SCREEN_RATIO_16_10 = 4.5f;
    const float SCREEN_RATIO_5_3 = 4.68f;
    const float SCREEN_RATIO_16_9 = 5f;
    const float SCREEN_RATIO_18_9 = 5.62f;
    const float SCREEN_RATIO_19_9 = 5.92f;
    const float SCREEN_RATIO_20_9 = 6.24f;
    const float SCREEN_RATIO_21_9 = 6.56f;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        float screenRatio = (float) Screen.height / Screen.width; // since this game is portrait, width is smaller than height, thus height / width
        float targetSize;
        if (screenRatio >= 21f / 9)
        {
            targetSize = SCREEN_RATIO_21_9;
            cam.transform.position = new Vector3(0f, 1.56f, -10f);
        }
        else if (screenRatio >= 20f / 9)
        {
            targetSize = SCREEN_RATIO_20_9;
            cam.transform.position = new Vector3(0f, 1.2f, -10f);
        }
        else if (screenRatio >= 19f / 9)
        {
            targetSize = SCREEN_RATIO_19_9;
            cam.transform.position = new Vector3(0f, 0.92f, -10f);
        }
        else if (screenRatio >= 18f / 9)
        {
            targetSize = SCREEN_RATIO_18_9;
            cam.transform.position = new Vector3(0f, 0.62f, -10f);
        }
        else if (screenRatio >= 16f / 9) targetSize = SCREEN_RATIO_16_9;
        else if (screenRatio >= 5f / 3)
        {
            targetSize = SCREEN_RATIO_5_3;
            cam.transform.position = new Vector3(0f, -0.32f, -10f);
        }
        else if (screenRatio >= 16f / 10)
        {
            targetSize = SCREEN_RATIO_16_10;
            cam.transform.position = new Vector3(0f, -0.5f, -10f);
        }
        else if (screenRatio >= 3f / 2)
        {
            targetSize = SCREEN_RATIO_3_2;
            cam.transform.position = new Vector3(0f, -0.79f, -10f);
        }
        else if (screenRatio >= 4f / 3)
        {
            targetSize = SCREEN_RATIO_4_3;
            cam.transform.position = new Vector3(0f, -1.26f, -10f);
        }
        else targetSize = SCREEN_RATIO_4_3; // another else? really? who have that kind of device?

        cam.orthographicSize = targetSize;
    }
}
