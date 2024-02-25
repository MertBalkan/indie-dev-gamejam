using UnityEngine;

namespace SnaileyGame.Inputs
{
    public class PcInput : IInput
    {
        public bool HookInput => Input.GetMouseButtonDown(0);
    }
}   