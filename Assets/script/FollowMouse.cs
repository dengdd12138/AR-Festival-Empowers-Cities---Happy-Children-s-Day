using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public bool hasFollow;// ��������Ƿ����ڸ������
    private Vector3 offset; // ��¼�����λ�����������ĵ�ƫ��
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
            
            // ��ȡ��굱ǰ����Ļ����
            Vector3 mousePosition = Input.mousePosition;
            // ��Z��������Ϊ���嵽������ľ��룬ȷ�����������������ͬ��ƽ�����ƶ�
            mousePosition.z = distanceToCamera;
            // ������������Ļ����ת��Ϊ��������
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // ���������λ�ã�������ԭ�о����������λ��
            transform.position = worldMousePosition;
            /*
            // ��ȡ��굱ǰ����Ļ����
            Vector3 mousePosition = Input.mousePosition;
            // ��Z��������Ϊ��������ͬ��ֵ��ȷ��������XYƽ�����ƶ�
            mousePosition.z = curZ;
            // ������������Ļ����ת��Ϊ��������
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            // ������λ������Ϊ�����������꣬���Ǳ�����Z���겻��
            transform.position = new Vector3(-worldMousePosition.x, -worldMousePosition.y, curZ);
            */
            /*
            // ��ȡ���������ռ��е�λ��
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = curZ; // ����������ͬһƽ��
            transform.position = mousePosition + offset; // ��������λ��Ϊ���λ�ü���ƫ��*/
        }
    }

    private void OnMouseEnter()
    {
        if (hasFollow)
            return;

        // �������嵽������ĳ�ʼ����
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
        // �����������ʱ����ʼ�������
        hasFollow = true;
        /*
        // ���������λ�����������ĵ�ƫ��
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset.z = 0;*/
    }
}
