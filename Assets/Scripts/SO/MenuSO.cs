using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu()]
    public class MenuSO : ScriptableObject
    {
        public List<CookingRecipeSO> MenuList;
    }
}
