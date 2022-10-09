﻿using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class UserSecretKeyManager : ManagerRepositoryBase<UserSecretKey, IUserSecretKeyRepository>, IUserSecretKeyService
    {
        protected UserSecretKeyManager(IUserSecretKeyRepository repository) : base(repository)
        {
            base.SetValidator(new UserSecretKeyValidator());
        }

        public string GenerateSecretKey(int roleId)
        {
            var objId = Repository.GetNextId();
            var key = new Random().Next(0, (int)Math.Pow(10, 9)).ToString("D9");
            var roleHex = GetHex(roleId);
            var keyList = SplitNumbers(key);
            int target;
            for (int i = 0; i < roleHex.Count; i++)
            {
                target = (objId % keyList.Count) - 1;

                keyList[target] = roleHex[i].ToString();
                objId *= 2;
            }

            return string.Join("", keyList);
        }

        private int ParseToken(string token)
        {
            int target, tokenId = Repository.Get(k => k.SecretKey == token.Trim()).Id;

            var roleHex = "";
            var keyList = SplitNumbers(token);

            for (int i = 0; i < 2; i++)
            {
                target = (tokenId % keyList.Count) - 1;
                roleHex += token[target];
                tokenId *= 2;
            }

            return GetDecimal(roleHex);
        }

        private List<int> GetHex(int n)
        {
            var result = new List<int>();

            while (n != 0)
            {
                result.Add(n % 8);
                n /= 8;
            }
            int count = result.Count;
            for (int i = 0; i < 2 - count; i++)
            {
                result.Add(0);
            }
            return result.Reverse<int>().ToList();
        }

        private int GetDecimal(string hex)
        {
            int result = 0;

            for (int i = 0; i < hex.Length; i++)
            {
                result += (int)Math.Pow(8, hex.Length - 1 - i) * int.Parse(hex[i].ToString());
            }

            return result;
        }

        private List<string> SplitNumbers(string key)
        {
            var result = new List<string>();

            for (int i = 0; i < key.Length; i++)
            {
                result.Add(key[i].ToString());
            }

            return result;
        }
    }
}
