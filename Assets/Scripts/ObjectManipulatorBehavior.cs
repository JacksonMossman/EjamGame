using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulatorBehavior  : MonoBehaviour
{
    public Camera cam;
    public float interactDist;

    public Transform holdPos;
    public float attractSpeed;

    public float minThrowForce;
    public float maxThrowForce;
    private float throwForce;

    private GameObject objectIHave;
    private Rigidbody objectRB;

    private Vector3 rotateVector = Vector3.one;

    private bool hasObject = false;



    private void Start()
    {
        throwForce = minThrowForce;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasObject)
        {
            DoRay();
        }

        if (Input.GetMouseButton(1) && hasObject)
        {
            throwForce += 0.1f;
        }

        //if (Input.GetMouseButtonUp(1) && hasObject)
        //{
        //    ShootObj();
        //}

        if (Input.GetKeyDown(KeyCode.G) && hasObject)
        {
            DropObj();
        }

        if (hasObject)
        {
            RotateObj();

            if (CheckDist() >= 1f)
            {
                MoveObjToPos();
            }
        }
        CalculateRotVector();



    }



    //----------------Polish Stuff
    private void CalculateRotVector()
    {
        float x;
        float y;



        x = Input.GetAxis("Vertical");



        y = Input.GetAxis("Horizontal");


        //x =Input.GetAxis("Vertical");



        //float y = Input.GetAxis("Horizontal"); ;
        float z = Input.GetAxis("Pitch");
        if (Input.GetAxis("Stop") != 0)
        {
            objectRB.angularVelocity = new Vector3(0, 0, 0);
        }
        else
        {
            rotateVector = new Vector3(x, y, z) * 10;
        }

      
    }

    private void RotateObj()
    {
       // Rigidbody rb = objectIHave.GetComponent<Rigidbody>();
        objectRB.AddTorque(rotateVector);
        //objectIHave.transform.Rotate(rotateVector,Space.World);
    }


    //----------------Functinoal Stuff

    public float CheckDist()
    {
        float dist = Vector3.Distance(objectIHave.transform.position, holdPos.transform.position);
        return dist;
    }

    private void MoveObjToPos()
    {
        if(objectRB.velocity.magnitude > 0)
        {
            objectRB.velocity = new Vector3();
        }
        objectIHave.transform.position = Vector3.Lerp(objectIHave.transform.position, holdPos.position, attractSpeed * Time.deltaTime);
    }

    private void DropObj()
    {
        objectRB.constraints = RigidbodyConstraints.None;
        objectIHave.transform.parent = null;
        objectRB.useGravity = true;
        objectIHave = null;
        hasObject = false;
    }

    //private void ShootObj()
    //{
    //    throwForce = Mathf.Clamp(throwForce, minThrowForce, maxThrowForce);
    //    objectRB.AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);
    //    throwForce = minThrowForce;
    //    DropObj();
    //}

    private void DoRay()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDist))
        {
            if (hit.collider.CompareTag("Block") || hit.collider.CompareTag("Ingredient"))
            {
                objectIHave = hit.collider.gameObject;
                objectIHave.transform.SetParent(holdPos);

                objectRB = objectIHave.GetComponent<Rigidbody>();
                objectRB.constraints = RigidbodyConstraints.None;
                objectRB.useGravity = false;

                hasObject = true;

                CalculateRotVector();
            }
        }
    }
        // Start is called before the first frame update

    // Update is called once per frame
    

}
