using System;

namespace GameOff2024.Game.Utility
{
    public static class CustomExtension
    {
        public static string ToDescription(this Skill skill)
        {
            return skill switch
            {
                Skill.ChipGetUp => "Increase chip acquisition amount by {0}%",
                Skill.ChipLostDown => "Reduce chip loss by {0}%",
                Skill.ChipGetLostUp => "Increased chip gain and chip loss by {0}%",
                Skill.ChipGetLostDown => "Reduce chip gain and chip loss by {0}%",
                _ => throw new Exception(),
            };
        }
    }
}