using System.Collections.Generic;
using System.Linq;
using Web.Models.ProductViewModel;

namespace Web.Helper
{
    public class FilterData
    {
        public List<IndexProductViewModel> Filter(List<IndexProductViewModel> data, double startPriceAt = 0, double endPriceAt = double.MaxValue, double startRatingAt = 0, double endRatingAt = 5)
        {
            var _list = data;

            _list = _list.Where(x =>
                            x.Price >= startPriceAt &&
                            x.Price <= endPriceAt &&
                            x.Rating >= startRatingAt &&
                            x.Rating <= endRatingAt)
                                .ToList();

            return _list;
        }
    }
}
