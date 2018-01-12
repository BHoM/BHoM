namespace BH.oM.Queries
{
    public class CustomQuery : IQuery
    {
        /***************************************************/
        /**** Properties                                ****/
        /***************************************************/

        public string Query { get; set; }


        /***************************************************/
        /**** Constructors                              ****/
        /***************************************************/

        public CustomQuery(string query = "")
        {
            Query = query;
        }
    }
}