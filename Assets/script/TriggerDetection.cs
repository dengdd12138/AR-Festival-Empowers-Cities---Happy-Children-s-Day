using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject movingObject;
    public Animator animator;
    [Header("三个小球碰撞完后触发的动画")]
    public List<Animator> animators = new();
    public GameObject sceneGO;
    private bool touchedTarget1 = false;
    private bool touchedTarget2 = false;
    private bool touchedTarget3 = false;
    private Rigidbody movingObjectRb;
    // 设置一个临时变量来存储物体初始位置的Z坐标
    private float objectZ;
    [Header("触发物体的动画")]
    public List<Animator> anims = new();
    [Header("触发物体")]
    public List<GameObject> objects = new();
    void Awake()
    {
        /*
        // 获取运动物体的刚体组件
        movingObjectRb = movingObject.GetComponent<Rigidbody>();
        if (movingObjectRb == null)
        {
            // 如果没有刚体组件，则输出错误消息
            Debug.LogError("MovingObject does not have a Rigidbody component attached.");
        }
        else
        {
            // 开始时禁止运动
            movingObjectRb.isKinematic = true;
        }*/
        objectZ = transform.position.z;
    }

    void Update()
    {
        // 发射射线从摄像机位置到鼠标位置
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            // 检查射线是否碰撞到Collider
            Collider collider = hitInfo.collider;
            if (collider != null)
            {
                // 获取碰撞到的Collider的名称
                string colliderName = collider.gameObject.name;
                Debug.Log("Collider name: " + colliderName);
                OnTargetTouch(colliderName);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            
        }
        /*
        // 获取鼠标当前的屏幕坐标
        Vector3 mousePosition = Input.mousePosition;
        // 将Z坐标设置为与物体相同的值，确保物体在XY平面上移动
        mousePosition.z = objectZ;
        // 将鼠标坐标从屏幕坐标转换为世界坐标
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        // 将物体位置设置为鼠标的世界坐标，但是保持其Z坐标不变
        transform.position = new Vector3(worldMousePosition.x, worldMousePosition.y, objectZ);*/
    }
    /*
        void Update()
        {
            // 获取鼠标在世界空间中的位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 保持 z 轴不变
            mousePosition.z = movingObject.transform.position.z;
            // 更新运动物体的位置
            movingObject.transform.position = mousePosition;
        }
    */

    public void OnTargetTouch(string targetName)
    {
        // 这里你可以根据Collider的名称执行相应的逻辑
        if (targetName == "Target1")
        {
            Debug.Log("Target1 touched");
            touchedTarget1 = true;
            // 执行你的逻辑...
        }
        if (targetName == "Target2" && touchedTarget1)
        {
            Debug.Log("Target2 touched");
            touchedTarget2 = true;
        }
        if (targetName == "Target3" && touchedTarget2)
        {
            Debug.Log("Target3 touched");
            touchedTarget3 = true;
        }
        // 检查是否三个小球都已触碰
        if (touchedTarget1 && touchedTarget2 && touchedTarget3)
        {
            sceneGO.SetActive(true);
            // 启动其他运动物体的运动
            foreach (Animator anim in animators)
            {
                anim.SetTrigger("Trigger");
            }
        }

        int index = GetIndex(targetName);
        if (index != -1)
        {
            anims[index].SetTrigger("Trigger");
        }
    }

    int GetIndex(string targetName)
    {

        int index = 0;
        foreach (GameObject go in objects)
        {
            if (go.name == targetName)
            {
                return index;
            }
            index++;
        }

        return -1;
    }





    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target1")
        {
            Debug.Log("Target1 touched");
            touchedTarget1 = true;
        }
        if (other.gameObject.name == "Target2" && touchedTarget1)
        {
            Debug.Log("Target2 touched");
            touchedTarget2 = true;
        }
        if (other.gameObject.name == "Target3" && touchedTarget2)
        {
            Debug.Log("Target3 touched");
            touchedTarget3 = true;
        }


        // 检查是否三个小球都已触碰
        if (touchedTarget1 && touchedTarget2 && touchedTarget3)
        {
            // 启动运动物体的运动
            //animator.SetTrigger("isTrigger");

            // 启动其他运动物体的运动
            foreach (Animator anim in animators)
            {
                sceneGO.SetActive(true);
                anim.SetTrigger("Trigger");
            }
        }
    }*/
}