using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool hasFollow;// 标记物体是否正在跟随鼠标
    private Vector3 offset; // 记录鼠标点击位置与物体中心的偏移
    public float curZ;
    private float distanceToCamera;
    private void Start()
    {
        curZ = transform.position.z;
    }
    private void Update()
    {
        if (hasFollow)
        {
            
            // 获取鼠标当前的屏幕坐标
            Vector3 mousePosition = Input.mousePosition;
            // 将Z坐标设置为物体到摄像机的距离，确保物体在与摄像机相同的平面上移动
            mousePosition.z = distanceToCamera;
            // 将鼠标坐标从屏幕坐标转换为世界坐标
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // 更新物体的位置，保持在原有距离摄像机的位置
            transform.position = worldMousePosition;
            /*
            // 获取鼠标当前的屏幕坐标
            Vector3 mousePosition = Input.mousePosition;
            // 将Z坐标设置为与物体相同的值，确保物体在XY平面上移动
            mousePosition.z = curZ;
            // 将鼠标坐标从屏幕坐标转换为世界坐标
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // 将物体位置设置为鼠标的世界坐标，但是保持其Z坐标不变
            transform.position = new Vector3(-worldMousePosition.x, -worldMousePosition.y, curZ);
            */
            /*
            // 获取鼠标在世界空间中的位置
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = curZ; // 保持与物体同一平面
            transform.position = mousePosition + offset; // 设置物体位置为鼠标位置加上偏移*/
        }
    }

    private void OnMouseEnter()
    {
        if (hasFollow)
            return;

        // 计算物体到摄像机的初始距离
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        // 当鼠标点击物体时，开始跟随鼠标
        hasFollow = true;
        /*
        // 计算鼠标点击位置与物体中心的偏移
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;*/
    }
}
