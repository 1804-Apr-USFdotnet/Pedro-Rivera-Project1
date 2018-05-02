using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestaurantReviewsLibrary
{
    public static class Serialize
    {
        public static string ToJson<T>(this T self) => JsonConvert.SerializeObject(self);
    }
}
