using UnityEditor.Rendering;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float RunSpeed;
    [SerializeField] private float ApplySpeed;
    private bool isRun = false;
    [SerializeField] private float lookSensitivity;
    [SerializeField] private float cameraRtatLimit;
    [SerializeField] private float currentCameraRotationX = 0;

    [SerializeField] private Camera theCamera;
    private Rigidbody myRigid;
    void Start()
    {
        theCamera = FindObjectOfType<Camera>();
        myRigid = GetComponent<Rigidbody>();
        ApplySpeed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        TryRun();
        Move();
        CharacterRotation();
        CameraRotation();
    }

    public void TryRun()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            Running();
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            RunningCancel();
        }
    }

    public void Running()
    {
        isRun = true;
        ApplySpeed = RunSpeed;
    }

    public void RunningCancel()
    {
        isRun = false;
        ApplySpeed = walkSpeed;
    }
    
    public void Move()
    {
        float _moveDirx = Input.GetAxisRaw("Horizontal");
        float _moveDirz = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right* _moveDirx;   
        Vector3 _moveVertical = transform.forward* _moveDirz;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * ApplySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);


    }
    public void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
        Debug.Log(myRigid.rotation);
        Debug.Log(myRigid.rotation.eulerAngles);
    }

    public void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, _cameraRotationX, cameraRtatLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f); 
    }

}
