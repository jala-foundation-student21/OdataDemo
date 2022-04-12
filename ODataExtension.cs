using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace ODataWebAPI
{
    public static class ODataExtension
    {
        // EDM is short for Entity Data Model
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Press>("Presses");
            builder.EntitySet<Companies>("Companies");        
            return builder.GetEdmModel();
        }
    }
}
