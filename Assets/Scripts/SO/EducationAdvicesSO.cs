using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu()]
    public class EducationAdvicesSO : ScriptableObject
    {
        public string FirstEducationText;
        public string StartEducationButtonText;
        public string SkipEducationButtonText;

        public List<string> Advices = new List<string>(33) { };
    }
}


