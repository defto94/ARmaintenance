using UnityEngine;

public class Rotation : MonoBehaviour
{
    private GameObject rotatingObject;
    public GameObject baseOfLabel;

    private void Start()
    {
        rotatingObject = gameObject;
        rotatingObject.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, baseOfLabel.transform.up);
    }

    private void Update()
    {
        rotatingObject.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, baseOfLabel.transform.up);
    }
}