using Core.Collection;

namespace Web.Models.OrderViewModel
{
    public class OrderIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
