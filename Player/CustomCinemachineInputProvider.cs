using Cinemachine;

namespace Ellisar.EllisarAssets.Scripts.Player
{
    public class CustomCinemachineInputProvider : CinemachineInputProvider
    {
        public bool InputEnabled = true;

        public override float GetAxisValue(int axis)
        {
            if (!InputEnabled)
                return 0;
            return base.GetAxisValue(axis);
        }
    }
}
