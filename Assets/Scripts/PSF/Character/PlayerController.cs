using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Joystick joystick;
    public GameObject joystickButtonBox;

    public float speed = 6f;
    public float gravity = -9.8f;
    public float jumpForce = 1f;
    float fallVelocity;
    public KeyCode grab;

    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;

    public bool cantMove = false;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float grabTime = 0.2f;
    public float dropTime = 0.2f;

    [Header("PickUp")]
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        float horizontaljoystick = joystick.Horizontal;
        float verticaljoystick = joystick.Vertical;
        Vector3 directionjoystick = new Vector3(horizontaljoystick, 0f, verticaljoystick).normalized;

        SetGravity();

        PlayerSkills();

        if(PickedObject != null){
            GetComponent<Animator>().SetBool("carrying", true);
        }

        if (direction.magnitude >= 0.1f && !cantMove)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if(PickedObject == null){
                GetComponent<Animator>().SetBool("walking", true);
            }else if(PickedObject != null){
                GetComponent<Animator>().SetBool("carrying", true);
            }
        }else if(directionjoystick.magnitude >= 0.1f && !cantMove){
            float targetAngle = Mathf.Atan2(directionjoystick.x, directionjoystick.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

            if(PickedObject == null){
                GetComponent<Animator>().SetBool("walking", true);
            }else if(PickedObject != null){
                GetComponent<Animator>().SetBool("carrying", true);
            }
        
        }else{
            GetComponent<Animator>().SetBool("walking", false);
            GetComponent<Animator>().SetBool("carrying", false);
        }

        if(ObjectToPickUp != null)
        {
            joystickButtonBox.SetActive(true);
        }
        else
        {
            joystickButtonBox.SetActive(false);
        }
    }

    void SetGravity(){
    

        if (controller.isGrounded)
        {
            fallVelocity = gravity * Time.deltaTime;
            Vector3 gravityVector = new Vector3(0, fallVelocity, 0);
            controller.Move(gravityVector * Time.deltaTime);
        }else{
            fallVelocity -= gravity * Time.deltaTime;
            Vector3 gravityVector = new Vector3(0, fallVelocity, 0);
            controller.Move(gravityVector * Time.deltaTime);
        }

        

        SlideDown();

    }

    void PlayerSkills(){

        if (Input.GetKeyDown(grab))
        {

            PickUpObject();
        }
    }

    public void SlideDown(){
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= controller.slopeLimit;

        if(isOnSlope){
            Vector3 slideVector = new Vector3(hitNormal.x * slideVelocity, -slopeForceDown, hitNormal.z * slideVelocity);
            controller.Move(slideVector * Time.deltaTime);
        }
    
    
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        hitNormal = hit.normal;

    }

    public void PickUpObject()
    {
        if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            StartCoroutine("DropBox");
            StartCoroutine("GrabBox");
            
            GetComponent<Animator>().SetTrigger("grabbing");

            GetComponent<Animator>().SetBool("carrying", true);
            
        }

        else if (PickedObject != null)
        { 
            StartCoroutine("DropBox");
            PickedObject.GetComponent<PickableObject>().isPickable = true;
            PickedObject.transform.SetParent(null);
            PickedObject.GetComponent<Rigidbody>().useGravity = true;
            PickedObject.GetComponent<Rigidbody>().isKinematic = false;
            PickedObject = null;
            GetComponent<Animator>().SetTrigger("grabbing");
            GetComponent<Animator>().SetBool("carrying", false);
        }
    }

    private IEnumerator GrabBox(){

        yield return new WaitForSeconds(grabTime);

        PickedObject = ObjectToPickUp;
        PickedObject.GetComponent<PickableObject>().isPickable = false;
        PickedObject.transform.SetParent(interactionZone);
        PickedObject.transform.position = interactionZone.position;
        PickedObject.transform.rotation = interactionZone.rotation;
        PickedObject.GetComponent<Rigidbody>().useGravity = false;
        PickedObject.GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Animator>().SetBool("carrying", true);
    }

    private IEnumerator DropBox(){
        cantMove = true;
        yield return new WaitForSeconds(dropTime);

        cantMove = false;

    }
}
