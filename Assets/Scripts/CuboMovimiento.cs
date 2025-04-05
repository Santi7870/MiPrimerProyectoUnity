using UnityEngine;

public class CuboMovimiento : MonoBehaviour
{
    public float velocidad = 5f;  
    public float sensibilidad = 2f; 
    public Transform camara; 

    private float rotacionX = 0f;
    private float rotacionY = 0f;

    private bool moviendoCamara = false; 

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 

        Vector3 movimiento = new Vector3(horizontal, 0f, vertical);  
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World); 

        if (Input.GetMouseButton(1))  
        {
            moviendoCamara = true;
        }
        else
        {
            moviendoCamara = false;
        }

        if (moviendoCamara)
        {
            
            rotacionX += Input.GetAxis("Mouse X") * sensibilidad;
            rotacionY -= Input.GetAxis("Mouse Y") * sensibilidad;
            rotacionY = Mathf.Clamp(rotacionY, -90f, 90f); 

            camara.transform.position = transform.position + Quaternion.Euler(rotacionY, rotacionX, 0f) * new Vector3(0f, 5f, -10f);
            camara.transform.LookAt(transform.position); 
        }
        else
        {
            camara.transform.position = transform.position + new Vector3(0f, 5f, -10f);
            camara.transform.LookAt(transform.position);
        }
    }
}









