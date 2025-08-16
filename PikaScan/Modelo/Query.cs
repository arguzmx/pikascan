using System.Collections.Generic;

namespace PikaScan.Modelo
{
    public class Query : QueryParams
    {
        public Query()
        {

            this.Filters = new List<QueryFilter>();
        }

        public List<QueryFilter> Filters { get; set; }

    }



}
