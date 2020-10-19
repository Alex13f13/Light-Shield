using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    private float W = 10f;
    private float S = 90f;
    private float A = 70f;
    private float D = 0f;
    

    void Update()
    {
		if (GameManager.GameOverCheck)
		{
            this.enabled = false;
            return;
		}		

        if (transform.position.z >= W && (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness))
		{
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
		}
        if (transform.position.z <= S && (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness))
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (transform.position.x >= D && (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (transform.position.x <= A && (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
