using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to any GameObjects for simple Gizmo utilities
// Written by: Sam "FloydianSound" in June 2022

public class GizmoPlus : MonoBehaviour
{

// [SerializeField] public enum LineDrawingMode{Forward = 1,Target = 2,Children = 3,Parent = 4}

[Header("Line Settings")]
[SerializeField] Color lineColor = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float lineLength = 1;

[Header("Ray Settings")]
[SerializeField] Color rayColor = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float rayLength = 1;

[Header("Sphere Settings")]
[SerializeField] Color wireSphereColor = new Vector4 (1,1,1,1);
[SerializeField] Color sphereColor = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float sphereRadius = 1;

[Header("WireFrame Cube Settings")]
[SerializeField] Color wireCubeColor = new Vector4 (1,1,1,1f);
[Range(0,10)]
[SerializeField] private float wireCubeSize = 2;

[Header("Solid Cube Settings")]
[SerializeField] Color cubeColor = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float cubeSize = 2;


// Unity Events (Where Stuff Happens)
void OnDrawGizmos()
    {
        DrawWireSphere();
        DrawWireCube();
        DrawRayForward();
    }

void OnDrawGizmosSelected()
    {
        DrawLine();
        DrawCube();
        DrawSphere();
    } 
void Start()
    {

    }
void Update()
    {

    }
void LateUpdate() 
    {
        
    }

// Private Functions (What Actually Happens)
private void DrawWireSphere()
    {
        //Wireframe Sphere
        Gizmos.color = wireSphereColor;
        Gizmos.DrawWireSphere(transform.position, sphereRadius);
    }
private void DrawSphere()
    {
        //Sphere Render
        Gizmos.color = sphereColor;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
private void DrawLine()
    {
        //Forward Line Render, useful to see the rotation and orientation of our object
        Gizmos.color = lineColor;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.forward * lineLength));
    }
private void DrawWireCube()
    {
        // WireMesh Cube Render
        Gizmos.color = wireCubeColor;
        Gizmos.DrawWireCube(transform.position, new Vector3(wireCubeSize, wireCubeSize, wireCubeSize));
    }
private void DrawCube()
    {
        // Solid Cube Render
        Gizmos.color = cubeColor;
        Gizmos.DrawCube(transform.position, new Vector3(cubeSize, cubeSize, cubeSize));
    }
private void DrawRayForward()
    {
        // Forward Ray Render, useful to see the rotation and orientation of our object
        Vector3 direction = transform.TransformDirection(Vector3.forward) * rayLength;
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, direction);
    }
}
