using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCubeMatrix : MonoBehaviour
{
    [SerializeField] float x_spacing = 0;
    [SerializeField] float y_spacing = 0;
    [SerializeField] float z_spacing = 0;

    [SerializeField] int m_columns = 0;
    [SerializeField] int m_rows = 0;
    [SerializeField] int m_depth = 0;

    [SerializeField] GameObject m_prefab;

    [ContextMenu("MakeMatrix")]
    public void MakeCubes()
    {
        int maxCubes = m_columns * m_rows * m_depth;
        Vector3 pos = Vector3.zero;

        for(int i =0; i< m_depth; i++)
        {
            pos = new Vector3(0, 0, i * z_spacing);
            for (int j =0; j < m_columns; j++)
            {
                pos = new Vector3(0, j *y_spacing, i * z_spacing);
                for(int k =0; k < m_rows; k++)
                {
                    GameObject g = GameObject.Instantiate(m_prefab, transform);
                    g.transform.localPosition = pos;
                    pos += new Vector3(x_spacing, 0, 0);
                }
            }
        }
    }

    [ContextMenu("clear Matrix")]
    public void ClearCubes()
    {
        Transform[] transform_list = GetComponentsInChildren<Transform>();

        foreach(Transform t in transform_list)
        {
            DestroyImmediate(t.gameObject);
        }
    }
}
