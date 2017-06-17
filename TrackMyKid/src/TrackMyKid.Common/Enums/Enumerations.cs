using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Enums
{
    public class Enumerations
    {

        public enum eResponseStatusCode
        {
            _SUCCESS = 00,
            _FAILURE = 01,
            _API_LAYER_FAILURE = 101,
            _DATA_LAYER_FAILURE = 102,
            _BUSINESS_LAYER_FAILURE = 103,
            _DB_FAILURE = 104,
            _CODE_FAILURE = 104,
            _VALIDATION_FAILURE = 105,
            _APPLICATION_FAILURE = 106
        }
        public enum eResponseStatusCodeDetails
        {
            InvalidOperation,
            InvalidRequest,
            InvalidUser,
            ResourceNotFound
        }

    }
}
