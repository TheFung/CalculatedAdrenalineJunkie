using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruck : MonoBehaviour
{
    public void SelfDestroy() => Destroy(this, 0.2f);
}
