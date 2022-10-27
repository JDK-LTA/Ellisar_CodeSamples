using Ellisar.EllisarAssets.Scripts.LevelInteractions.Interactables;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.LevelInteractions.RuneStar_Puzzle
{
    public class ActivateRune : Interactable
    {
        [Title("Rune Specific")]
        [SerializeField, MinValue(0)] private int runeIndex;

        protected override void CanActivateTrue()
        {
            base.CanActivateTrue();
            RunePuzzleManager.Instance.CheckAndSetPathFalse(runeIndex);
        }


        protected override void Act()
        {
            base.Act();
            RunePuzzleManager.Instance.ActivateRune(runeIndex);
        }
    }
}
