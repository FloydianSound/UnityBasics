using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class LightingController : MonoBehaviour
{

    [SerializeField] private Animator m_Animator;
    [SerializeField] private LineRenderer l_renderer;
    [SerializeField] private LookAtConstraint lookAt_Constraint;
    [SerializeField] private float dimmer;
    [SerializeField] private float angle;
    [SerializeField] private float length;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        l_renderer = GetComponent<LineRenderer>();
        lookAt_Constraint = GetComponent<LookAtConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForKeyPress();
    }

    void CheckForKeyPress(){
        //Possible to make Case Switch ?!
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            m_Animator.SetInteger("Color", 0);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(1f,1f,1f,0.25f);
            Debug.Log("White");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1)){
            m_Animator.SetInteger("Color", 1);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(1f,0f,0f,0.25f);
            Debug.Log("Red");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2)){
            m_Animator.SetInteger("Color", 2);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(1f,0f,1f,0.25f);
            Debug.Log("Purple");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3)){
            m_Animator.SetInteger("Color", 3);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(0f,0f,1f,0.25f);
            Debug.Log("Blue");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4)){
            m_Animator.SetInteger("Color", 4);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(0f,1f,1f,0.25f);
            Debug.Log("Teal");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha5)){
            m_Animator.SetInteger("Color", 5);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(0f,1f,0f,0.25f);
            Debug.Log("Green");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha6)){
            m_Animator.SetInteger("Color", 6);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(1f,1f,0f,0.25f);
            Debug.Log("Yellow");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha7)){
            m_Animator.SetInteger("Color", 7);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(1f,1f,1f,0.25f);
            Debug.Log("Fade");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha8)){
            m_Animator.SetInteger("Color", 8);
            l_renderer.startColor = new Color(1f,1f,1f,0.25f);
            l_renderer.endColor = new Color(1f,1f,1f,0.25f);
            Debug.Log("Snap");
        }

        // Intensity, could use Min/Max of 0-1
        if(Input.GetKeyDown(KeyCode.PageUp)){
            if(dimmer < 1f){
                dimmer = dimmer + 0.1f;
                m_Animator.SetFloat("Dimmer", dimmer);
                Debug.Log("Dimmer Up : " + dimmer);
            }
            else if(dimmer > 1f){
                dimmer = 1f;
            }
        }
        else if(Input.GetKeyDown(KeyCode.PageDown)){
            if(dimmer > 0f){
            dimmer = dimmer - 0.1f;
            m_Animator.SetFloat("Dimmer", dimmer);
            Debug.Log("Dimmer Down : " + dimmer);
            }
            else if(dimmer < 0f){
                dimmer = 0f;
            }
        }

        //Angle of the spotlight
        if(Input.GetKeyDown(KeyCode.LeftBracket)){
            angle = angle - 0.05f;
            m_Animator.SetFloat("Angle", angle);
            Debug.Log("Angle Down : " + angle);
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket)){
            angle = angle + 0.05f;
            m_Animator.SetFloat("Angle", angle);
            Debug.Log("Angle Up : " + angle);
        }

        //Length of the spotlight
        if(Input.GetKeyDown(KeyCode.Minus)){
            length = length - 0.1f;
            m_Animator.SetFloat("Length", length);
            Debug.Log("Length Down : " + length);
        }
        else if(Input.GetKeyDown(KeyCode.Equals)){
            length = length + 0.1f;
            m_Animator.SetFloat("Length", length);
            Debug.Log("Length Up : " + length);
        }

        //Boolean for Moving Animation / Cosntraint
        if(Input.GetKeyDown(KeyCode.Home)){
            m_Animator.SetBool("IsMoving", true);
            lookAt_Constraint.constraintActive = false;
            Debug.Log("Animator Started");
            Debug.Log("Constraint Disabled");
        }
        else if(Input.GetKeyDown(KeyCode.End)){
            m_Animator.SetBool("IsMoving", false);
            lookAt_Constraint.constraintActive = true;
            Debug.Log("Animator Stopped");
            Debug.Log("Constraint Enabled");
        }

        //LookAt Constraint Weight
        if(Input.GetKeyDown(KeyCode.M)){
            if(lookAt_Constraint.weight < 1f){
            lookAt_Constraint.weight = lookAt_Constraint.weight + 0.1f;
            Debug.Log("Lookat Weight UP:" + lookAt_Constraint.weight);
            }
        }
        else if(Input.GetKeyDown(KeyCode.N)){
            if(lookAt_Constraint.weight > -1f){
            lookAt_Constraint.weight = lookAt_Constraint.weight - 0.1f;
            Debug.Log("Lookat Weight DOWN:" + lookAt_Constraint.weight);
            }
        }

    }
}

