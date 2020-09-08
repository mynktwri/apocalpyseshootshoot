using UnityEngine;

[RequireComponent(typeof(PlayerMove))]   
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float LookSensitivity = 3;
    private PlayerMove move;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<PlayerMove>();

    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;

        //calculate movement velocity as a 3d vector
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");
        //float _yMovement = Input.GetAxisRaw("Horizontal");

        Vector3 _movH = transform.right * _xMov; // (1, 0, 0)
        Vector3 _movV = transform.forward * _zMov; // (0, 0, 1)

        Vector3 _velocity = (_movH + _movV).normalized * speed;

        move.Move(_velocity);


        //calcluate rotation as a 3d vector left and right oNLY
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * LookSensitivity;

        //apply rotation
        move.Rotate(_rotation);

        //calcluate CAMERA rotation as a 3d vector UP AND DOWN Only
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRot, 0f, 0f) * LookSensitivity;

        //apply CAMERA rotation
        move.RotateCamera(_cameraRotation);
    }
}
