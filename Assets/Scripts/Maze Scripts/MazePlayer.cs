using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazePlayer : MonoBehaviour
{
    float speed = 3.0f;
    public int taskPoints = 0;
    public int taskResult = 0; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

    }

    int collectCount(int collectID)
    {
        if (collectID == 0)
        {
            taskPoints += 1;
        } else if (collectID == 1)
        {
            taskPoints += 2;
        }

        return taskPoints;
    }

    int checkTaskResult()
    {
        if (taskPoints == 2)
        {
            Debug.Log("Neutral Result");
            return taskResult = 1;
        }
        else if (taskPoints > 2)
        {
            Debug.Log("Good Result");
            return taskResult = 2;
        }
        else return taskResult;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //exiting the maze
        if (collision.gameObject.tag == "MazeExit")
        {
            Destroy(collision.gameObject);
            checkTaskResult();
            Debug.Log("Mini Game Complete");
        }

        //running into an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //collecting a good item
        if (collision.gameObject.tag == "GoodCollect")
        {
            Destroy(collision.gameObject);
            collectCount(1);
        }

        //collecting a neutral item
        if (collision.gameObject.tag == "NeutralCollect")
        {
            Destroy(collision.gameObject);
            collectCount(0);
        }

        //How to bounce off of the walls
        if (collision.gameObject.tag == "Walls")
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
    }


}
