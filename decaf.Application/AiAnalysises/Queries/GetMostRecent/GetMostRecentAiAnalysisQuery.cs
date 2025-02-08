using decaf.Application.AiAnalysises.Common;
using MediatR;

namespace decaf.Application.AiAnalysises.Queries.GetMostRecent;

public class GetMostRecentAiAnalysisQuery : IRequest<AiAnalysisDto?>
{
    public int ChannelId { get; set; }
}
