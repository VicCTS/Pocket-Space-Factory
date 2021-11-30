using UnityEngine;
using UnityEngine.AI;

public class RayMenu : MonoBehaviour
{
    public MenuManager menuManager;
    public Animator anim;

    private NavMeshAgent agente;
    private Vector3 initialPoint;
    private bool isReturningInitialPoint;
    private bool isMenuClicked;
    private int menuOption;

    void Start()
    {
        anim.SetBool("run",false);
        agente = GetComponent<NavMeshAgent>();
        initialPoint = transform.position;
        isReturningInitialPoint = false;
        isMenuClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*100, Color.cyan);
        RaycastHit hit;
        
        if(Input.GetMouseButtonDown(0) && isMenuClicked == false)
        {
                if(Physics.Raycast(ray, out hit) == true)
                {
                    var selection = hit.transform;
                    if(selection.CompareTag("Options") || selection.CompareTag("Play") || selection.CompareTag("Exit"))
                    {
                        agente.destination = hit.point;
                        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
                        Debug.Log(hit.transform.gameObject.tag);
                        anim.SetBool("run",true);
                        if (selection.CompareTag("Options"))
                        {
                            menuOption = 1;
                        }
                        if (selection.CompareTag("Play"))
                        {
                            menuOption = 2;
                        }
                        if (selection.CompareTag("Exit"))
                        {
                            menuOption = 3;
                        }
                    } 
                }     
        }

        if (isReturningInitialPoint == true)
        {
            float dist = Vector3.Distance(initialPoint, transform.position);
            Debug.Log("return distance: " + dist);
            if (dist < 0.5f)
            {
                anim.SetBool("run", false);
                isReturningInitialPoint = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Options") || other.gameObject.CompareTag("Play") || other.gameObject.CompareTag("Exit"))
        {
            anim.SetBool("run", false);
            isMenuClicked = true;
        }

        if (other.gameObject.CompareTag("Options") && menuOption == 1)
        {
            menuManager.ShowOptionsMenu();
        }

        if (other.gameObject.CompareTag("Exit") && menuOption == 3)
        {
            menuManager.ShowExitMenu();
        }

        if (other.gameObject.CompareTag("Play") && menuOption == 2)
        {
            menuManager.ShowPlayMenu();
        }
    }

    public void ReturnToStartPoint()
    {
        agente.destination = initialPoint;
        anim.SetBool("run", true);
        isReturningInitialPoint = true;
        isMenuClicked = false;
    }
}