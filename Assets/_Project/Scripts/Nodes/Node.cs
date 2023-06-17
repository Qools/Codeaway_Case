using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    private Renderer nodeRenderer;

    [SerializeField] private Vector3 positionOffset = new Vector3(0f, 0.5f, 0f);
    [SerializeField] private Color highLightColor;
    private Color startColor;

    public GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        nodeRenderer = GetComponent<Renderer>();
        startColor = nodeRenderer.material.color;
    }


    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            return;
        }

        nodeRenderer.material.color = highLightColor;
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //if (!BuildManager.Instance.CanBuild)
        //{
        //    return;
        //}

        if (turret != null)
        {
            Debug.Log("node is used");
            return;
        }

        BuildManager.Instance.BuildTurretOn(this);
    }

    public Vector3 GetOffsetPosition()
    {
        return transform.position + positionOffset;
    }
}
