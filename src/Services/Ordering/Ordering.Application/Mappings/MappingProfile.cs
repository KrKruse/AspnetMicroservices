using AutoMapper;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ordering.Application.Features.Orders.Queries.GetOrdersList;

namespace Ordering.Application.Mappings
{
    public class MappingProfile : Profile
    {
        // adgang til mapping i gennem f.eks getorderlistqueri  
        public MappingProfile()
        {
            CreateMap<Order, OrdersVm>().ReverseMap();
        }
    }
}
