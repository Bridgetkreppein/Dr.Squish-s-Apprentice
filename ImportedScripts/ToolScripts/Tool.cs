using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject waterProjectilePrefab;
    public GameObject ballProjectilePrefab;
    public GameObject glueProjectilePrefab;

    public Transform shootPoint;

    public Transform handTransform;
    private bool isToolEquipped = false;

    private enum ToolMode { Ball, Water, Glue }
    private ToolMode currentMode = ToolMode.Ball;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipTool(!isToolEquipped);
        }

        if (isToolEquipped)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentMode = ToolMode.Ball;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentMode = ToolMode.Water;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                currentMode = ToolMode.Glue;
            }

            if (Input.GetMouseButtonDown(0))
            {
                ShootProjectile(GetProjectilePrefabForCurrentMode(), GetTargetPoint());
            }
        }
    }

    public void EquipTool(bool equip)
    {
        isToolEquipped = equip;

        if (isToolEquipped)
        {
            transform.SetParent(handTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            transform.SetParent(null);
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }

    void ShootProjectile(GameObject projectilePrefab, Vector3 targetPoint)
    {
        if (projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Projectile projectileScript = projectile.GetComponent<Projectile>();

            if (projectileScript != null)
            {
                projectileScript.SetDirection(targetPoint);
            }
        }
    }

    Vector3 GetTargetPoint()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return ray.GetPoint(100);
    }

    GameObject GetProjectilePrefabForCurrentMode()
    {
        switch (currentMode)
        {
            case ToolMode.Water:
                return waterProjectilePrefab;
            case ToolMode.Ball:
                return ballProjectilePrefab;
            case ToolMode.Glue:
                return glueProjectilePrefab;
            default:
                return ballProjectilePrefab;
        }
    }
}