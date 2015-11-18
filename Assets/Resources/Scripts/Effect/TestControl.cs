using UnityEngine;
using System.Collections;

public class TestControl : MonoBehaviour 
{
    private Vector3 m_velocity;

	void Start () 
    {
        m_velocity = new Vector3( 0.1f, 0.1f, 0.1f );
	}
	
	void Update () 
    {
	    if( Input.GetKey( KeyCode.LeftArrow ) == true )
        {
            transform.position -= new Vector3( m_velocity.x, 0.0f, 0.0f );
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position += new Vector3(m_velocity.x, 0.0f, 0.0f);
        }



        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            transform.position -= new Vector3(0.0f, 0.0f, m_velocity.z);
        }

        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            transform.position += new Vector3(0.0f, 0.0f, m_velocity.z);
        }


        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.position += new Vector3(0.0f, m_velocity.y, 0.0f);
        }

        if (Input.GetKey(KeyCode.Z) == true)
        {
            transform.position -= new Vector3(0.0f, m_velocity.y, 0.0f);
        }
	}
}
