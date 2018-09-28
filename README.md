## Objective

Main objective of this blog post is to give you an idea about how to use Enemy Aim Ai Unity Tutorial.


## Step 1 : Introduction

**You will get Final Output:**

![](http://www.theappguruz.com/app/uploads/2015/06/enemyaim.gif)

Enemy aim AI is very useful when you want an enemy to aim towards the player controller. Proper aiming towards an object takes time in real world scenario, so the enemy will take some amount of time before it locks on the target. This effect can be created by Lerping Rotation angles of the enemy towards the player.

This kind of scenario is very useful in case of action games, where the enemy follows, aims and then shoots the player. The concept on Enemy follow is already discussed in a blog posted earlier.

Understanding the concept of Quaternion is very essential while implementing aiming in games.

Quaternion stores the rotation of an object and also evaluates the orientation value. One can directly play with Euler Angles, but there may arise situations of GimbalLock. According to the local coordinate system, if you rotate a model about its X axis then its Y and Z axis experiences a Gimbal lock and become "locked" together. One can go through Unity Manual for more information on Quaternion.


## Step 2 : Example

Now Getting Back to our Topic, Given Below is a simple example to explain Enemy Aim AI.

Follow the steps given below.

### 2.1 Create Cube

Create a Cube which will act upon player control

- Apply appropriate materials as per the requirement to its Mesh Renderer.
- Apply TargetMovementScript to GameObject.
- This Cube will act as an object which will move on player’scommands.

![](http://www.theappguruz.com/app/uploads/2015/06/inspector.jpg)

**TargetMovementScript.cs**

```csharp
public class TargetMovementScript : MonoBehaviour {
public float targetSpeed=9.0f;//Speed At Which the Object Should Move
void Update () {
transform.Translate (Input.GetAxis ("Horizontal")*Time.deltaTime*targetSpeed,Input.GetAxis ("Vertical")*Time.deltaTime*targetSpeed,0);
}
}
```

### 2.2 Create Enemy Object

Create an Enemy Object which consists of an Arrow and a Cube

- Apply appropriate material to the cube.
- Take an arrow sprite as a different gameObject.
- Position it in such a way that its non pointing point faces towards the Cube. So here, Arrow will act as the Gun of the enemy.
- This arrow will point towards the Target Object and it would look as if it is trying to lock an Aim on that target.
- We can also manipulate the speed at which the enemy would be able to lock on the target properly; as different enemies should be of different difficulty as well as different capabilities.
- A tank should take more time to lock on in comparison to a soldier aiming with his Gun. So the speed at which one can lock on the target should be different.

![](http://www.theappguruz.com/app/uploads/2015/06/arrow-pointnig.png)

**EnemyAimScript.cs**

```csharp
public class EnemyAimScript : MonoBehaviour {
 
public Transform target; // Target Object
public float enemyAimSpeed=5.0f; // Speed at Which Enenmy locks on the Target
Quaternion newRotation;
float orientTransform;
float orientTarget;
void Update () {
orientTransform = transform.position.x;
orientTarget = target.position.x;
// To Check on which side is the target , i.e. Right or Left of this Object
if (orientTransform > orientTarget) {
// Will Give Rotation angle , so that Arrow Points towards that target
newRotation = Quaternion.LookRotation (transform.position - target.position, -Vector3.up);
}
else {
newRotation = Quaternion.LookRotation (transform.position - target.position,Vector3.up);
}
 
// Here we have to freeze rotation along X and Y Axis, for proper movement of the arrow
newRotation.x = 0.0f;
newRotation.y = 0.0f;
 
// Finally rotate and aim towards the target direction using Code below
transform.rotation = Quaternion.Lerp (transform.rotation,newRotation,Time.deltaTime * enemyAimSpeed);
 
// Another Alternative
// transform.rotation = Quaternion.RotateTowards(transform.rotation,newRotation, Time.deltaTime * enemyAimSpeed);
}
}
```

### 2.3 Default View

Hierarchy and Scene View would be something like as given below.

![](http://www.theappguruz.com/app/uploads/2015/06/hierrchy-arrow-pointing.png)

## Step 3 : Notes

- One can change the speed at which the enemy aims and locks the target.
- One can play with the script by allowing X or Y axis rotation for the purpose of understanding the concept.
- One can add Follow Script to Enemy, so that the enemy follows and aims towards the player.
- Instead of using Quaternion.Lerp one can also Quaternion.RotateTowards for giving the same effect.
