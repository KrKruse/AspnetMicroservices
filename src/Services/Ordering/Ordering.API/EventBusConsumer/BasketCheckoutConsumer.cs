using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Features.Orders.Command.CheckoutOrder;

namespace Ordering.API.EventBusConsumer
{
    // consume/subribe interface gør at klassen subscriber på basketcheckoutevent - masstransit trickers consume hvis der er nogen basket/kurve der bliver aktiveret 
    public class BasketCheckoutConsumer : IConsumer<BasketCheckoutEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<BasketCheckoutConsumer> _logger;

        public BasketCheckoutConsumer(IMediator mediator, IMapper mapper, ILogger<BasketCheckoutConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
        {
            // context.message er BasketCheckoutEvent objekt 
            var command = _mapper.Map<CheckoutOrderCommand>(context.Message);
            // Vil gå til handler klassen CheckoutOrderCommandHandler i application laget under feautures og lave en ny opdatering til databsen ved brug af repository 
            var result = await _mediator.Send(command);

            _logger.LogInformation("BasketCheckoutEvent consumed succesfuldt. Ordre Id : {newOrderId}", result);
        }
    }
}
