using System;
using UniEx;

namespace GameOff2024.Common
{
    public sealed class UserVO
    {
        public readonly string uid;
        public readonly UserNameVO name;

        public UserVO(string uid, string name)
        {
            this.uid = uid;
            this.name = new UserNameVO(name);
        }
    }

    public sealed class UserNameVO
    {
        public readonly string value;

        public UserNameVO(string value)
        {
            // TODO: Exception
            if (IsInvalid(value)) throw new Exception();

            this.value = value;
        }

        private static bool IsInvalid(string value)
        {
            return
                string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value) ||
                value.Length.IsBetween(PlayFabConfig.MIN_NAME_LENGTH, PlayFabConfig.MAX_NAME_LENGTH) == false;
        }
    }
}