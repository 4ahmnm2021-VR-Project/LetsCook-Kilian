using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pointer : MonoBehaviour
{
    public float m_DefaultLength = 5.0f;
    public GameObject m_Dot;
    public VRInputModule m_inputModule;
    private LineRenderer m_LineRenderer = null;
    void Awake() {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        UpdateLine();
    }

    void UpdateLine() {
        float targetLenght = m_DefaultLength;
        RaycastHit hit = CreateRaycast(targetLenght);
        Vector3 endPosition = transform.position + (transform.forward * targetLenght);

        if(hit.collider != null) {
            endPosition = hit.point;
        }

        m_Dot.transform.position = endPosition;

        m_LineRenderer.SetPosition(0, transform.position);
        m_LineRenderer.SetPosition(1, endPosition);
    }

    RaycastHit CreateRaycast(float lenght) {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLength);
        return hit;
    }
}
