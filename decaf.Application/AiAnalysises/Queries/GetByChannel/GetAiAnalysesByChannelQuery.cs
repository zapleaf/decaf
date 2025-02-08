using decaf.Application.AiAnalysises.Common;
using MediatR;

namespace decaf.Application.AiAnalysises.Queries.GetByChannel;

public class GetAiAnalysesByChannelQuery : IRequest<List<AiAnalysisDto>>
{
    public int ChannelId { get; set; }
}