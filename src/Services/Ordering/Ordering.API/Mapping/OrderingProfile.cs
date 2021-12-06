using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Command.CheckoutOrder;

namespace Ordering.API.Mapping
{
    // arver fra profile der er fra automapper
    public class OrderingProfile : Profile
    {
        // mapping for CheckoutOrderCommand fra application laget og BasketCheckoutEvent fra eventbus + reversenmap, så man kan gør det fra begge sider 
        public OrderingProfile()
        {
            CreateMap<CheckoutOrderCommand, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
