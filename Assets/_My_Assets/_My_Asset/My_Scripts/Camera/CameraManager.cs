using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Camera mainCamera;

    private bool usingVirtualCam = true;

    protected void SetCamBack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            usingVirtualCam = !usingVirtualCam;
            if (usingVirtualCam)
            {
                virtualCamera.gameObject.SetActive(true);
            }
            else
            {
                virtualCamera.gameObject.SetActive(false);
                mainCamera.gameObject.SetActive(true);
            }
        }
        if (!usingVirtualCam)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            if (x < 10)
            {
                mainCamera.transform.position -= Vector3.left * Time.deltaTime * 10f;

            }
            else if (x > Screen.width - 10)
            {
                mainCamera.transform.position -= Vector3.right * Time.deltaTime * 10f;
            }
            if (y < 10)
            {
                mainCamera.transform.position -= Vector3.back * Time.deltaTime * 10f;
            }
            else if (y > Screen.height - 10)
            {
                mainCamera.transform.position -= Vector3.forward * Time.deltaTime * 10f;
            }
        }
    }
    private void Update()
    {
        SetCamBack();
    }
}
