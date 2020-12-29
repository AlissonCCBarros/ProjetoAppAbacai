using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Domain.Model
{

    public class CurrentUser
    {

        private string _token;

        public void Init(string token, Dictionary<string, object> claims)
        {
            this._token = token;
            this._claims = claims;
        }

        private Dictionary<string, object> _claims;

        public string GetToken()
        {
            return this._token;
        }

        public Dictionary<string, object> GetClaims()
        {
            return this._claims;
        }

        public TS GetUserId<TS>()
        {
            var subjectId = this._claims
                .Where(_ => _.Key.ToLower() == "sub")
                .SingleOrDefault()
                .Value;

            return (TS)Convert.ChangeType(subjectId, typeof(TS));
        }

        public int GetUserId()
        {
            return this.GetUserId<int>();
        }

    }
}
