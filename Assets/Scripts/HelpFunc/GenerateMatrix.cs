using UnityEngine;

public class GenerateMatrix : MonoBehaviour
{
    public static GameObject[][] MatrixGenerate(GameObject gm, Vector2 pos, SetValue setValue, int n, int m, float coef)
    {
        GameObject[][] arr = new GameObject[n][];
        GameObject buf;
        GameObject squarePool = new GameObject();
        squarePool.name = "squarePool";
        float rx;
        
        if (m % 2 == 0)
            rx = (pos.x + gm.transform.localScale.x/2);
        else
            rx = pos.x;

        pos = new Vector2(rx, pos.y);
        Vector2 bufVector = pos;
        
        for (int i = 0; i < n; i++)
        {
            arr[i] = new GameObject[m];
            for (int j = 0; j < m; j++)
            {
                buf = Instantiate(gm, bufVector, Quaternion.identity);
                buf.SetActive(false);
                buf.GetComponent<SquareScript>().setValue = setValue;
                buf.transform.SetParent(squarePool.transform);
                arr[i][j] = buf;
                bufVector += new Vector2(buf.transform.localScale.x + coef, 0);
            }
            bufVector = new Vector2(pos.x, bufVector.y);
            bufVector -= new Vector2(0, gm.transform.localScale.y + coef);
        }
        return arr;
    }

    public static SpriteRenderer[] GetSpriteRendererFromGMArray(GameObject[] gmArray)
    {
        int n = gmArray.Length;
        SpriteRenderer[] arr = new SpriteRenderer[n];
        for (int i = 0; i < n; i++)
            arr[i] = gmArray[i].transform.GetChild(0).GetComponent<SpriteRenderer>();
        return arr;
    }
}
