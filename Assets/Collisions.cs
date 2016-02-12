using UnityEngine;
using System.Collections;

public class Collisions : MonoBehaviour {

    private int x = 0;

    public void calc(Collider2D one, Collider2D two) {

        if (x == 1)
        {
            x = 0;

            Vector3 normal = new Vector3(two.transform.position.x - one.transform.position.x, two.transform.position.y - one.transform.position.y);
            Vector3 unitNormal = normal / normal.magnitude;
            Vector3 unitTangent = new Vector3(unitNormal.y * -1, unitNormal.x);
            Vector3 velocity = new Vector3(one.gameObject.GetComponent<EnemyMovement>().xDir, one.gameObject.GetComponent<EnemyMovement>().yDir);
            Vector3 hitVelocity = new Vector3(two.gameObject.GetComponent<EnemyMovement>().xDir, two.gameObject.GetComponent<EnemyMovement>().yDir);

            float v1n = Vector3.Dot(unitNormal, velocity), v1t = Vector3.Dot(unitTangent, velocity),
                  v2n = Vector3.Dot(unitNormal, hitVelocity), v2t = Vector3.Dot(unitTangent, hitVelocity);

            Vector3 v1nPrime = unitNormal * v2n, v1tPrime = unitTangent * v1t, v2nPrime = unitNormal * v1n, v2tPrime = unitTangent * v2t;
            Vector3 v1Prime = v1nPrime + v2nPrime, v2Prime = v2nPrime + v2tPrime;

            one.gameObject.GetComponent<EnemyMovement>().xDir = v1Prime.x;
            one.gameObject.GetComponent<EnemyMovement>().yDir = v1Prime.y;
            two.gameObject.GetComponent<EnemyMovement>().xDir = v2Prime.x;
            two.gameObject.GetComponent<EnemyMovement>().yDir = v2Prime.y;

        }
        else { x++; }

    }
	
}
