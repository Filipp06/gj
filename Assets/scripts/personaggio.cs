using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class personaggio : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Vector2 moveInput = Vector2.zero;

    public void OnMove(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
        //Debug.Log(moveInput);
    }

  
    void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y) * moveSpeed;

        transform.position += movement * moveSpeed * Time.deltaTime;

        if(movement != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime);
        }
    }
}
