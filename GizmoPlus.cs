using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to any GameObjects for simple Gizmo utilities
// Written by: Sam "FloydianSound" in June 2022

public class GizmoPlus : MonoBehaviour
{

[Header("Line Settings")]
[SerializeField] Color lineColor = new Vector4 (1,1,1,0.5f);
[SerializeField] private enum LineDrawingMode{None, Target, Children, WorldOrigin}; // Construct the Enum
[SerializeField] LineDrawingMode lineDrawingMode; // Cast the Enum into a Dropdown
[SerializeField] private Transform target;

[Header("Ray Settings")]
[SerializeField] private bool rayToggle = true;
[SerializeField] Color rayColor = new Vector4 (1,1,1,0.5f);
[Range(0,1000)]
[SerializeField] private float rayLength = 10;

[Header("WireSphere Settings")]
[SerializeField] private bool wireSphereToggle = true;
[SerializeField] Color wireSphereColor = new Vector4 (1,1,1,1);
[Range(0,10)]
[SerializeField] private float wireSphereRadius = 1;

[Header("Sphere Settings (Selection Only)")]
[SerializeField] private bool sphereToggle = true;
[SerializeField] Color sphereColor = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float sphereRadius = 1;

[Header("WireFrame Cube Settings")]
[SerializeField] private bool wireCubeToggle = true;
[SerializeField] Color wireCubeColor = new Vector4 (1,1,1,1f);
[Range(0,10)]
[SerializeField] private float wireCubeSize = 2;

[Header("Cube Settings (Selection Only)")]
[SerializeField] private bool cubeToggle = true;
[SerializeField] Color cubeColor = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float cubeSize = 2;

[Header("Camera Frustum Settings")]
[SerializeField] private bool frustumToggle = false;
[Range(1,180)]
[SerializeField] private float fov = 60;
[SerializeField] Color frustumColorStart = new Vector4 (1,1,1,0.5f);
[SerializeField] Color frustumColorEnd = new Vector4 (1,1,1,0.5f);
[Range(0,10)]
[SerializeField] private float frustumMinRange = 0.3f; //unity Default
[Range(10,1000)]
[SerializeField] private float frustumMaxRange = 100f; //Unity Default
[Range(0,2)]
[SerializeField] private float aspectRatio = 1.777f; //close enough to 16:9

void Update()
{

}

// Unity Events (When Stuff Happens)
void OnDrawGizmos()
    {
        if (wireSphereToggle != false)
        {
            DrawWireSphere();
        }
        if (wireCubeToggle != false)
        {
            DrawWireCube();
        }
        if (rayToggle != false)
        {
            DrawRayForward();
        }
        if (frustumToggle != false)
        {
            DrawCameraFrustum();
        }
    }

void OnDrawGizmosSelected()
    {
        if (sphereToggle != false)
        {
            DrawSphere();
        }
        if (cubeToggle != false)
        {
            DrawCube();
        }
        
        DrawLine();
        
        
    } 

// Private Functions (What Actually Happens)
private void DrawWireSphere()
    {
        //Wireframe Sphere
        Gizmos.color = wireSphereColor;
        Gizmos.DrawWireSphere(transform.position, wireSphereRadius);
    }
private void DrawSphere()
    {
        //Sphere Render
        Gizmos.color = sphereColor;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
private void DrawLine()
    {
        switch (lineDrawingMode)
        {
            case LineDrawingMode.None:
            {
                break;
            }
            case LineDrawingMode.Target:
            {
                DrawLineToTarget();
                break;
            }
            case LineDrawingMode.Children:
            {
                DrawLineToChildrens(transform);
                break;
            }
            case LineDrawingMode.WorldOrigin:
            {
                Vector3 worldOrigin = new Vector3(0,0,0);
                Gizmos.color = lineColor;
                Gizmos.DrawLine(transform.position, worldOrigin);
                Gizmos.color = Color.white;
                Gizmos.DrawWireSphere(worldOrigin, wireSphereRadius);
                break;
            }
        }
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
        //
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, direction);
    }

//LineDrawingMode Enum Subfunctions
private void DrawLineToTarget()
    {
        Gizmos.color = lineColor;
        Gizmos.DrawLine(transform.position, target.position);        
    }
private void DrawLineToChildrens(Transform trans) 
    {
        Gizmos.color = wireSphereColor;
        Gizmos.DrawWireSphere(trans.position, (wireSphereRadius * 0.5f));
        foreach (Transform child in trans) 
            {
                Gizmos.color = lineColor;
                Gizmos.DrawLine(trans.position, child.position);
                DrawLineToChildrens(child);
            }
    }
private void DrawCameraFrustum()
    {
        // i want T = vector between frustumMinRange and frustumMaxRange 
        float t = Mathf.PingPong(Time.unscaledTime, 1f); 
        Vector3 direction = transform.position; //transform.TransformDirection(Vector3.forward);
        //
        Gizmos.color = Color.Lerp(frustumColorStart, frustumColorEnd, t);
        Gizmos.DrawFrustum(direction, fov, frustumMaxRange, frustumMinRange, aspectRatio); // i need to this face forward local, not global
        // Debug.Log(t);
    }
}
