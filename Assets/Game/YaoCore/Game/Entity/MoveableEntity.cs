using UnityEngine;

public class MoveableEntity : Entity
{
    public void Move(Vector3 dir)
    {
        var lookAtPoint = (this.transform.position + dir);
            lookAtPoint.y = transform.position.y;

        transform.LookAt(lookAtPoint);
        transform.position += dir;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.W)) Move(new Vector3(0, 0, 1) * Time.deltaTime);
        if (Input.GetKey(KeyCode.S)) Move(new Vector3(0, 0, -1) * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) Move(new Vector3(-1, 0, 0) * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) Move(new Vector3(1, 0, 0) * Time.deltaTime);
    }
}
