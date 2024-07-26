using UnityEngine;
using System.Collections;

public class ParabolicGrenadeScript : MonoBehaviour
{
    #region Object Variables
    public Transform target; // The target point (player)

    [Tooltip("Height of the trajectory(Higher the number curver and higher the arc)")]
    public float peakHeight = 5f; // The peak height of the projectile

    public float gravity = -9.81f; // Gravity

    [Tooltip("Number of points to draw in the trajectory(Higher the number smoother the curve)")]
    public int resolution = 30; // Number of points to draw in the trajectory

    public GameObject explosionPrefab; // The explosion VFX prefab

    #endregion

    #region Private Variables

    private Vector3 initialPosition;
    private Vector3 initialVelocity;
    private float startTime;
    private bool hasExploded = false;

    #endregion

    public bool isGizmos = true;   //to check the trajectory of the granade in scene  

    void Start()
    {
        initialPosition = transform.position;
        initialVelocity = CalculateVelocity(initialPosition, target.position, peakHeight);
        startTime = Time.time;
    }

    void Update()
    {
        if (hasExploded) return;

        float time = Time.time - startTime;
        Vector3 currentPosition = initialPosition + initialVelocity * time + 0.5f * Vector3.up * gravity * time * time;
        transform.position = currentPosition;

        // Check if the grenade has reached the target
        if (Vector3.Distance(currentPosition, target.position) < 0.5f)
        {
            Explode();
        }
    }

    Vector3 CalculateVelocity(Vector3 start, Vector3 end, float height)
    {
        // Calculate the direction to the target
        Vector3 direction = end - start;
        Vector3 directionXZ = new Vector3(direction.x, 0, direction.z);

        // Calculate the time to reach the target
        float time = Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (direction.y - height) / gravity);

        // Calculate the velocity components
        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
        Vector3 velocityXZ = directionXZ / time;

        return velocityXZ + velocityY;
    }

    void Explode()
    {
        // Instantiate the explosion VFX at the current position
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Deactivate the grenade object and vfx
        gameObject.SetActive(false);
        hasExploded = true;
    }


    void OnDrawGizmos()
    {
        if (target == null || !isGizmos) return;

        // Draw the trajectory gizmo
        Gizmos.color = Color.red;
        Vector3 startPosition = Application.isPlaying ? initialPosition : transform.position;
        Vector3 velocity = CalculateVelocity(startPosition, target.position, peakHeight);
        float time = Mathf.Sqrt(-2 * peakHeight / gravity) + Mathf.Sqrt(2 * (target.position.y - startPosition.y - peakHeight) / gravity);

        for (int i = 0; i < resolution; i++)
        {
            float t1 = i / (float)resolution * time;
            float t2 = (i + 1) / (float)resolution * time;
            Vector3 point1 = startPosition + velocity * t1 + 0.5f * Vector3.up * gravity * t1 * t1;
            Vector3 point2 = startPosition + velocity * t2 + 0.5f * Vector3.up * gravity * t2 * t2;
            Gizmos.DrawLine(point1, point2);
        }

    }

}
