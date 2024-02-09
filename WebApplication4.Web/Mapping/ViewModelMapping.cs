using AutoMapper;
using WebApplication4.Web.Models;
using WebApplication4.Web.ViewModels;

namespace WebApplication4.Web.Mapping
{
    public class ViewModelMapping:Profile

    {
        public ViewModelMapping()
        {
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<Visitor,VisitorViewModel>().ReverseMap();
        }
    }
}
