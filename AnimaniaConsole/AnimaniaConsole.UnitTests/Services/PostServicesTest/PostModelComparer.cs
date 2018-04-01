using AnimaniaConsole.DTO.Models;
using System.Collections.Generic;

namespace AnimaniaConsole.UnitTests.Services.PostServicesTest
{
    public class PostModelComparer : Comparer<PostModel>
    {
        public override int Compare(PostModel x, PostModel y)
        {
            int comparison = x.Id.CompareTo(y.Id);
            if (comparison != 0) return comparison;

            comparison = x.Description.CompareTo(y.Description);
            if (comparison != 0) return comparison;

            return x.Title.CompareTo(y.Title);
        }
    }
}
