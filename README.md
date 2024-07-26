ParabolicGrenadeScript
Overview
ParabolicGrenadeScript is a Unity script designed for simulating a parabolic grenade trajectory. This script allows an object (the grenade) to follow a parabolic path to reach a specified target point. It includes functionality to visualize the grenade's trajectory in the Unity editor and handle explosion effects upon reaching the target.

Features
Parabolic Trajectory: Computes and moves the grenade along a parabolic path.
Gizmo Visualization: Visualizes the grenade's trajectory in the Unity editor for debugging purposes.
Explosion Effect: Triggers an explosion effect upon reaching the target.
Customization: Adjustable peak height of the trajectory and number of resolution points for the trajectory visualization.
Script Components
Public Variables
Transform target: The target point (player) that the grenade will aim towards.
float peakHeight: Height of the trajectory. Higher values result in a steeper curve and higher arc.
float gravity: The gravity affecting the projectile (default is -9.81 m/s²).
int resolution: Number of points used to draw the trajectory. Higher values result in a smoother curve.
GameObject explosionPrefab: Prefab for the explosion effect when the grenade hits the target.
Private Variables
Vector3 initialPosition: The initial position of the grenade.
Vector3 initialVelocity: The calculated initial velocity for the parabolic trajectory.
float startTime: Time when the grenade starts its trajectory.
bool hasExploded: A flag to indicate if the grenade has already exploded.
Public Methods
void Start(): Initializes the grenade's position, velocity, and start time.
void Update(): Updates the grenade's position along the trajectory and checks if it has reached the target.
void Explode(): Instantiates the explosion effect and deactivates the grenade.
Private Methods
Vector3 CalculateVelocity(Vector3 start, Vector3 end, float height): Calculates the initial velocity required for the grenade to follow a parabolic trajectory to the target.
void OnDrawGizmos(): Draws the trajectory of the grenade in the Unity editor for debugging purposes. Uses red lines to show the path.
Usage
Attach the Script: Attach the ParabolicGrenadeScript to a GameObject that represents the grenade.

Configure the Script:

Set the target variable to the GameObject representing the target.
Adjust peakHeight to control the arc of the trajectory.
Modify gravity if you need a different gravitational effect.
Set resolution to control the smoothness of the trajectory visualization.
Assign the explosionPrefab with the explosion effect you want to use.
Play the Scene: When you play the scene, the grenade will follow a parabolic path towards the target and explode upon reaching it.

Visualize the Trajectory: Enable the isGizmos flag to visualize the trajectory in the Unity editor.

Notes
Ensure the explosionPrefab is properly set up with any necessary particle systems or animations.
The CalculateVelocity method assumes a basic projectile motion equation. Adjustments might be needed based on specific gameplay requirements or physics settings.
