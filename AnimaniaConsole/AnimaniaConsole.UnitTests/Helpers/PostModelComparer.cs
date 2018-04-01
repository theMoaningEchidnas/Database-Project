using System.Collections.Generic;
using AnimaniaConsole.DTO.Models;

namespace AnimaniaConsole.UnitTests.Helpers
{
    public class PostModelComparer : Comparer<PostModel>
    {
        public override int Compare(PostModel x, PostModel y)
        {
            int comparison;

            comparison = x.Id.CompareTo(y.Id);
            if (comparison != 0) return comparison;

            comparison = x.Status.CompareTo(y.Status);
            if (comparison != 0) return comparison;

            comparison = x.Price.CompareTo(y.Price);
            if (comparison != 0) return comparison;

            comparison = x.UserId.CompareTo(y.UserId);
            if (comparison != 0) return comparison;

            comparison = x.Description.CompareTo(y.Description);
            if (comparison != 0) return comparison;

            return x.Title.CompareTo(y.Title);
        }
    }
}
