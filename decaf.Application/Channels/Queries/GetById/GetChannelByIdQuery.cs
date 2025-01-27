using MediatR;
using decaf.Domain.Entities;
using decaf.Application.Channels.Common;

namespace decaf.Application.Channels.Queries.GetById;

public record GetChannelByIdQuery(int Id) : IRequest<ChannelDto>;
