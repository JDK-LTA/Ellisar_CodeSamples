namespace Ellisar.EllisarAssets.Scripts.Enums
{
    #region Skills

    public enum SkillType
    {
        Movement,
        CameraControl,
        Interaction,
        Transformation
    }

    public enum SkillState
    {
        Enabled,
        Disabled
    }

    public enum SkillEquip
    {
        Default,
        PowerUp
    }

    #endregion
    
    #region Player

    public enum PlayerModeState
    {
        Biped,
        Fly,
        Agile
    }

    public enum BipedState
    {
        Grounded,
        OnAir
    }
    
    public enum BipedMovementState
    {
        Static,
        Walking,
        Sliding
    }
    
    public enum FlyModeState
    {
        Plane,
        High
    }

    public enum FlyState
    {
        Flying,
        Stunned
    }

    public enum AgileState
    {
        Walking,
        Charging,
        Jumping
    }

    public enum AgileModeState
    {
        Jumper,
        Slider
    }
    
    #endregion
    
    #region Movement

    public enum MovementTypeEnum
    {
        Composite,
        OneAxis,
        Modifier
    }

    public enum CompositeTypeEnum
    {
        TwoAxis,
        AllAxis
    }

    public enum CompositeTwoAxisTypeEnum
    {
        RightForward,
        RightUp,
        UpForward
    }

    public enum OneAxisTypeEnum
    {
        Right,
        Up,
        Forward
    }

    public enum ModifierTypeEnum
    {
        Modifier
    }
    
    public enum Coord
    {
        x,
        y,
        z
    }

    #endregion

    public enum Stage
    {
        CaveIn,
        CaveOut,
        Village,
        FlyTutorial,
        JellyIsland,
        WaterTunnel,
        Exploration,
        Spyro,
        End
    }
}